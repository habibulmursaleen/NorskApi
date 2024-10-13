public class Quiz
{
    public Guid Id { get; set; }
    public Guid EssayId { get; set; }
    public string Question { get; set; }
    public QuizType Type { get; set; } // Enum: MULTIPLE_CHOICE, BOOLEAN, STRING
    public List<QuizOption> Options { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

