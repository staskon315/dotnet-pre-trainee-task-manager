interface ITaskRepository
{
    public  Task<int> CreateAsync(TaskItem task);
    public Task<IEnumerable<TaskItem>> GetAllAsync(); 
    public Task<TaskItem?> GetByIdAsync(int id);
    public Task<bool> UpdateAsync(TaskItem task);
    public Task<bool> CompleteAsync(int id);
    public Task<bool> DeleteAsync(int id);  
}