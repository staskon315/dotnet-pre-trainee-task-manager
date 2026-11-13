class TaskService
{
    private readonly TaskRepository taskRepository;
    public TaskService(TaskRepository taskRep)
    {
        taskRepository = taskRep;
    }

    public async Task<bool> CreateTask()
    {
        Console.WriteLine($"Enter the task name");
        string title = Validation.GetValidInputForString();
        Console.WriteLine($"Enter a description of the task");
        Console.Write("Input: ");
        string? description = Console.ReadLine();
        Console.WriteLine($"Select whether the task has been completed or not.");
        bool isCompleted = Validation.GetValidInputForBool();
        var task = new TaskItem(title, description, isCompleted);
        int? id = await taskRepository.CreateAsync(task);
        if (id is null) return false;
        else
        {
            Console.WriteLine($"Task created with ID={id}");
            return true;
        }
    }

    public async Task ShowAll()
    {
        var tasks = await taskRepository.GetAllAsync();
        if (tasks is null)
        {
            Console.WriteLine("The database is empty");
            return;
        }
        else
        {
            foreach (var task in tasks)
                Console.WriteLine($"{task.Id}: {task.Title} | Completed: {task.IsCompleted}");
        }
    }

    public async Task FindTaskById()
    {
        Console.WriteLine("Enter the ID of the task you are interested in");
        Console.WriteLine("Imput: ");
        int id = Validation.GetValidInputForNumber();
        TaskItem? task = await taskRepository.GetByIdAsync(id);
        if (task is null)
        {
            Console.WriteLine("Task not found");
            return;
        }
        else
        {
            Console.WriteLine($"{task.Id}: {task.Title} |Description: {task.Description} |Completed: {task.IsCompleted} |Created at: {task.CreatedAt}");
            return;
        }
    }

    public async Task CompleteTask()
    {
        Console.WriteLine("Enter the ID of the task you have completed");
        Console.WriteLine("Imput: ");
        int id = Validation.GetValidInputForNumber();
        bool response = await taskRepository.CompleteAsync(id);
        if (response == false)
        {
            Console.WriteLine("Failed to complete the task");
            return;
        }
        else
        {
            Console.WriteLine("The task has been successfully completed.");
            return;
        }
    }

    public async Task DeleteTask()
    {
        Console.WriteLine("Enter the ID of the task you want to delete");
        Console.WriteLine("Imput: ");
        int id = Validation.GetValidInputForNumber();
        Console.WriteLine("Are you sure?");
        Console.WriteLine("Imput: ");
        bool answer = Validation.GetValidInputForBool();
        if (answer)
        {
            bool response = await taskRepository.DeleteAsync(id);
            if (response == false)
            {
                Console.WriteLine("Failed to delete the task");
                return;
            }
            else
            {
                Console.WriteLine("Task successfully deleted");
                return;
            }
        }

    }
}