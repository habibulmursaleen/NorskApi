public class GrammarTopic
{
    public Guid Id { get; set; }
    public string Label { get; set; }
    public string Description { get; set; }
    public GrammarTopicStatus Status { get; set; } // Enum: ACTIVE, INACTIVE
    public int Chapter { get; set; }
    public int ModuleCount { get; set; }
    public int Progress { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsSaved { get; set; }
    public List<string> Tags { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<GrammarRule> Rules { get; set; }
    public List<Task> Tasks { get; set; }
}
