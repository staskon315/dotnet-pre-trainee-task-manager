using Microsoft.Data.SqlClient;
using Dapper;

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

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TaskItem?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(TaskItem task)
    {
        throw new NotImplementedException();
    }
        public Task<bool> CompleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}