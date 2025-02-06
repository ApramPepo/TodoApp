public class TodoItem
{
    public int Id { get; set; }
    public string TaskName { get; set; } = string.Empty;
    public TodoItem()
    {
        TaskName = string.Empty;
    }
    public bool Completed { get; set; }
}