public class Essay
{
    public Guid Id { get; set; }
    public string Logo { get; set; } // URL or Base64 string
    public string Label { get; set; }
    public string Description { get; set; }
    public EssayStatus Status { get; set; } // Enum: ACTIVE, INACTIVE
    public int Progress { get; set; }
    public List<ActivityType> Activities { get; set; } // Enum: Paragraphs, Discussions, Quizzes, Words, Roleplay
    public bool IsCompleted { get; set; }
    public bool IsSaved { get; set; }
    public List<string> Tags { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Paragraph> Paragraphs { get; set; }
    public List<AdditionalContent> AdditionalContents { get; set; }
    public List<Guid> RelatedGrammarTopicIds { get; set; }
}
