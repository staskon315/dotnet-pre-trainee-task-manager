using Microsoft.Data.SqlClient;
using Dapper;
class Program
{
    static async Task Main()
    {
        var rep= new TaskRepository();
        var task = new TaskItem(1,"dapper2","123",false);
        bool res = await rep.CreateAsync(task);
        Console.WriteLine(res);
        var c= await rep.GetAllAsync();
        foreach(var r in c)
        {
            Console.WriteLine( $"{r.Id}: {r.Title} | Completed: {r.IsCompleted}");
        }

      
        
    }
}