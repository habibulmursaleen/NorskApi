public class Task
{
    public Guid Id { get; set; }
    public Guid TopicId { get; set; }
    public string Logo { get; set; }
    public string Label { get; set; }
    public string TaskPointer { get; set; }
    public string Answer { get; set; } // User input
    public string Comments { get; set; }
    public string AdditionalInfo { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
