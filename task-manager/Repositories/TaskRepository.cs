using Microsoft.Data.SqlClient;
using Dapper;
using System.ComponentModel;

public class TaskRepository : ITaskRepository
{
    //строку надо через констуктор
    private static string connectionString = "Server=localhost;Database=TaskManagementDb;Integrated Security=True;TrustServerCertificate=True;";

    public async Task<bool> CreateAsync(TaskItem task)
    {
        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        const string sql = """
            INSERT INTO Tasks(Title,Description,IsCompleted,CreatedAt)
            VALUES(@Title,@Description,@IsCompleted,@CreatedAt);
            """;
        int affectedRows = await connection.ExecuteAsync(sql, task);
        return affectedRows > 0;

    }

    public async Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        await using var connection = new SqlConnection(connectionString);
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
        await using var connection= new SqlConnection(connectionString);
        await connection.OpenAsync();

        const string sql="""
            SELECT Id, Title, Description, IsCompleted, CreatedAt
            FROM Tasks
            WHERE Id=@id
            """;
        var response= await connection.QuerySingleOrDefaultAsync<TaskItem>(sql, new{id});
        return response;
    }

    public async Task<bool> UpdateAsync(TaskItem task)
    {
        throw new NotImplementedException();
    }
    public async Task<bool> CompleteAsync(int id)
    {
        await using var connection= new SqlConnection(connectionString);
        await connection.OpenAsync();

        const string sql="""
            UPDATE Tasks SET IsCompleted=1
            WHERE Id=@id
            """;
        var response= await connection.ExecuteAsync(sql, new{id});
        return response>0;
    }
}