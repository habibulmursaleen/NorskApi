public class QuizOption
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsCorrect { get; set; }
    public string Answer { get; set; } // User input (string or bool)
}
