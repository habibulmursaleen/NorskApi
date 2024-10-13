public class Paragraph
{
    public Guid Id { get; set; }
    public Guid EssayId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
