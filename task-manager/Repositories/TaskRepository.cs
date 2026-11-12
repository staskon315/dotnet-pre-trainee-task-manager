using Microsoft.Data.SqlClient;
using Dapper;

public class TaskRepository
{
    private static string connectionString = "Server=localhost;Database=TaskManagementDb;Integrated Security=True;TrustServerCertificate=True;";
    public async Task<bool> AddTaskAsync(TaskItem task)
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

}