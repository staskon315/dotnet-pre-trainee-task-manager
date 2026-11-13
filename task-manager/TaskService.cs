class TaskService
{
    private readonly TaskRepository taskRepository;
    public TaskService(TaskRepository taskRep)
    {
        taskRepository=taskRep;
    }
    public async Task<bool> CreateTask()
    {
        Console.WriteLine($"Enter the task name");
        string title = Validation.GetValidInputForString();
        Console.WriteLine($"Enter a description of the task");
        string? description = Console.ReadLine();
        Console.WriteLine($"Enter the task status");
        bool isCompleted = Validation.GetValidInputForBool();
        var task = new TaskItem(title, description, isCompleted);
        int id = -1;
        id = await taskRepository.CreateAsync(task);
        if(id==-1) return false;
        else
        {
            Console.WriteLine($"Task created with ID={id}");
            return true;
        }
    }
}