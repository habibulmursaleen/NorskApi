public class GrammarRule
{
    public Guid Id { get; set; }
    public Guid TopicId { get; set; }
    public string Label { get; set; }
    public string Description { get; set; }
    public string ExplanatoryNotes { get; set; }
    public List<string> SentenceStructure { get; set; }
    public string RuleType { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, etc.
    public List<string> Tags { get; set; }
    public string Exceptions { get; set; }
    public string AdditionalInformation { get; set; }
    public List<Example> Examples { get; set; }
    public List<string> Comments { get; set; }
    public Transformation Transformation { get; set; }
    public List<Guid> RelatedRuleIds { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
