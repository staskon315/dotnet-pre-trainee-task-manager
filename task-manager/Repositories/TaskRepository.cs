using Microsoft.Data.SqlClient;
using Dapper;
using System.ComponentModel;

public class TaskRepository : ITaskRepository
{
    private readonly string ConnectionString;
    public TaskRepository(string connectionString)
    {
        ConnectionString = connectionString;
    }


    public async Task<int> CreateAsync(TaskItem task)
    {
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sql = """
            INSERT INTO Tasks(Title,Description,IsCompleted,CreatedAt)
            OUTPUT INSERTED.Id
            VALUES(@Title,@Description,@IsCompleted,@CreatedAt);
            """;
        int newTaskId = await connection.QuerySingleAsync<int>(sql, task);
        return newTaskId;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();
        const string sql = """
            DELETE FROM Tasks 
            WHERE Id=@Id
            """;
        var affectedRows = await connection.ExecuteAsync(sql, new { id });
        return affectedRows > 0;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sql = """
            SELECT Id, Title, Description, IsCompleted, CreatedAt
            FROM Tasks
            """;
        var response = await connection.QueryAsync<TaskItem>(sql);
        return response;
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sql = """
            SELECT Id, Title, Description, IsCompleted, CreatedAt
            FROM Tasks
            WHERE Id=@id
            """;
        var response = await connection.QuerySingleOrDefaultAsync<TaskItem>(sql, new { id });
        return response;
    }

    public async Task<bool> UpdateAsync(TaskItem task)
    {
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();
        const string sql = """
            UPDATE Tasks SET 
            Description=@Description,
            Title=@Title
            WHERE Id=@Id
            """;
        var affectedRows = await connection.ExecuteAsync(sql, task);
        return affectedRows > 0;
    }
    public async Task<bool> CompleteAsync(int id)
    {
        await using var connection = new SqlConnection(ConnectionString);
        await connection.OpenAsync();

        const string sql = """
            UPDATE Tasks SET IsCompleted=1
            WHERE Id=@id
            """;
        var affectedRows = await connection.ExecuteAsync(sql, new { id });
        return affectedRows > 0;
    }
}