using Microsoft.Data.SqlClient;
using Dapper;
class Program
{
    static async Task Main()
    {
        var rep= new TaskRepository();
        var res= rep.GetByIdAsync(3);
        var res2= rep.GetByIdAsync(99999);
        var res3= rep.GetByIdAsync(-33333);
        var t=await Task.WhenAll(res,res3,res2);
        foreach(var r in t)
        {
            if (r == null)
            {
                Console.WriteLine(33333333333);
                continue;
            }
            Console.WriteLine( $"{r.Id}: {r.Title} | Completed: {r.IsCompleted}");
        }

      
        
    }
}