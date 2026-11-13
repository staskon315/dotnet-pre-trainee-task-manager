class TaskService
{
    private readonly ITaskRepository taskRepository;
    public TaskService(ITaskRepository taskRep)
    {
        taskRepository = taskRep;
    }

    public async Task CreateTask()
    {
        Console.WriteLine("Enter the task name");
        string title = Validation.GetValidInputForString();
        Console.WriteLine($"Enter a description of the task");
        Console.Write("Input: ");
        string? description = Console.ReadLine();
        Console.WriteLine("Select whether the task has been completed or not.");
        bool isCompleted = Validation.GetValidInputForBool();
        var task = new TaskItem(title, description, isCompleted);
        int? id = await taskRepository.CreateAsync(task);
        if (id is null)
        {
            Console.WriteLine("Task not created");
            return;
        }
        else
        {
            Console.WriteLine($"Task created with ID={id}");
            return ;
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

    public async Task UpdateTask()
    {
        Console.WriteLine("Enter the ID of the task you want to update.");
        Console.Write("Input: ");
        int id=Validation.GetValidInputForNumber();
        Console.WriteLine("Enter the new task name");
        string title = Validation.GetValidInputForString();
        Console.WriteLine("Enter a new description of the task");
        Console.Write("Input: ");
        string? description = Console.ReadLine();
        Console.WriteLine("Select whether the task has been completed or not.");
        bool isCompleted = Validation.GetValidInputForBool();
        var task = new TaskItem(id,title, description, isCompleted);
        bool isUpdate = await taskRepository.UpdateAsync(task);
        if (!isUpdate){
            Console.WriteLine("The task did not update. Please double-check the values ​​:(");
            return;
        }
        else
        {
            Console.WriteLine("The task was successfully updated.");
            return ;
        }
    }
}