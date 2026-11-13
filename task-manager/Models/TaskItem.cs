public class TaskItem
{
    public int Id{ get; set; }
    public string? Title{ get; set; }
    public string? Description{ get; set; }
    public bool IsCompleted{ get; set; }
    public DateTime CreatedAt{ get; set; }
    public TaskItem(int id , string title, string description, bool isCompleted)
    {
        Id=id;
        if (!string.IsNullOrWhiteSpace(title)) Title=title;
        else throw new ArgumentException("Title cannot be empty", nameof(title));
        Description=description;
        IsCompleted=isCompleted;
        CreatedAt=DateTime.UtcNow;

    }
    public TaskItem(string title, string description, bool isCompleted)
    {
        if (!string.IsNullOrWhiteSpace(title)) Title=title;
        else throw new ArgumentException("Title cannot be empty", nameof(title));
        Description=description;
        IsCompleted=isCompleted;
        CreatedAt=DateTime.UtcNow;

    }
    public TaskItem(){}
}