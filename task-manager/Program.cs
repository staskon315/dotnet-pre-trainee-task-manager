
using System.Reflection.Metadata;

class Program
{
    static async Task Main()
    {
        string connectionString = """
        Server=localhost;
        Database=TaskManagementDb;
        Integrated Security=True;
        TrustServerCertificate=True;
        """;
        var taskRepository = new TaskRepository(connectionString);
        var taskService = new TaskService(taskRepository);
        bool exit = false;

        while (!exit)
        {

            Console.WriteLine("\nSelect one of the following actions(Enter a number):");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. Show all tasks");
            Console.WriteLine("3. Find task by ID");
            Console.WriteLine("4. Update task");
            Console.WriteLine("5. Complete task");
            Console.WriteLine("6. Delete task");
            Console.WriteLine("7. Exit");
            Console.Write("Input: ");
            int choice = Validation.GetValidInputForNumber();
            switch (choice)
            {
                case 1:
                    bool taskCreated = await taskService.CreateTask();
                    if (!taskCreated) Console.WriteLine("Task not created");

                    break;
                case 2:
                    await taskService.ShowAll();
                    break;
                case 3:
                    await taskService.FindTaskById();
                    break;
                case 4:

                    break;
                case 5:
                    await taskService.CompleteTask();
                    break;
                case 6:

                    break;
                case 7:
                    exit = true;
                    Console.WriteLine("Program completion");
                    break;
                default:
                    Console.WriteLine("Invalid data entered. Please try again. ");
                    break;
            }



        }

    }
}