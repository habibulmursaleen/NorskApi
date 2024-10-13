public class Discussion
{
    public Guid Id { get; set; }
    public Guid EssayId { get; set; }
    public string Title { get; set; }
    public string DiscussionEssays { get; set; }
    public bool IsCompleted { get; set; }
    public string Note { get; set; } // User input
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
