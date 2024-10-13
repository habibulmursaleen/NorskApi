public class Dictation
{
    public Guid Id { get; set; }
    public Guid EssayId { get; set; }
    public string Content { get; set; }
    public string Answer { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
