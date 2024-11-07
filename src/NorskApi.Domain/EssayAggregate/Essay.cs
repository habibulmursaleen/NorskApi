using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.Entities.EssayAggregate.Events.DomainEvent;
using NorskApi.Domain.EssayAggregate.Entities;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

public sealed class Essay : AggregateRoot<EssayId, Guid>
{
    public string? Logo { get; set; } // URL or Base64 string
    public string Label { get; set; }
    public string? Description { get; set; }
    public double Progress { get; set; }
    public List<string>? Activities { get; set; } // Enum: Paragraphs, Discussions, Quizzes, Words, Roleplay
    public Status Status { get; set; } // Enum: ACTIVE, INACTIVE
    public string Notes { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsSaved { get; set; }
    public List<string>? Tags { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public List<TopicId>? RelatedGrammarTopicIds { get; set; }
    private readonly List<Paragraph> paragraphs = new List<Paragraph>();
    public IReadOnlyCollection<Paragraph> Paragraphs => this.paragraphs;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Essay() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Essay(
        EssayId id,
        string? logo,
        string label,
        string? description,
        double progress,
        List<string>? activities,
        Status status,
        string notes,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel,
        List<Paragraph> paragraphs,
        List<TopicId>? relatedGrammarTopicIds
    )
        : base(id)
    {
        this.Id = id;
        this.Logo = logo;
        this.Label = label;
        this.Description = description;
        this.Progress = progress;
        this.Activities = activities;
        this.Status = status;
        this.Notes = notes;
        this.IsCompleted = isCompleted;
        this.IsSaved = isSaved;
        this.Tags = tags;
        this.DifficultyLevel = difficultyLevel;
        this.paragraphs = paragraphs;
        this.RelatedGrammarTopicIds = relatedGrammarTopicIds;
    }

    public static Essay Create(
        string? logo,
        string label,
        string? description,
        double progress,
        List<string>? activities,
        Status status,
        string notes,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel,
        List<Paragraph> paragraphs,
        List<TopicId>? relatedGrammarTopicIds
    )
    {
        Essay essay =
            new(
                EssayId.CreateUnique(),
                logo,
                label,
                description,
                progress,
                activities,
                status,
                notes,
                isCompleted,
                isSaved,
                tags,
                difficultyLevel,
                paragraphs,
                relatedGrammarTopicIds
            );

        essay.AddDomainEvent(new EssayCreatedDomainEvent(essay));

        return essay;
    }

    public void Update(
        string? logo,
        string label,
        string? description,
        double progress,
        List<string>? activities,
        Status status,
        string notes,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel,
        List<Paragraph> paragraphs,
        List<TopicId>? relatedGrammarTopicIds
    )
    {
        this.Logo = logo;
        this.Label = label;
        this.Description = description;
        this.Progress = progress;
        this.Activities = activities;
        this.Status = status;
        this.Notes = notes;
        this.IsCompleted = isCompleted;
        this.IsSaved = isSaved;
        this.Tags = tags;
        this.DifficultyLevel = difficultyLevel;
        this.RelatedGrammarTopicIds = relatedGrammarTopicIds;

        UpdateParagraphs(paragraphs);
        this.AddDomainEvent(new EssayUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new EssayDeletedDomainEvent(this));
    }

    private void UpdateParagraphs(List<Paragraph>? newParagraphs)
    {
        if (newParagraphs is not null)
        {
            // Update existing paragraphs or add new ones
            foreach (var newParagraph in newParagraphs)
            {
                var existingParagraph = this.paragraphs?.FirstOrDefault(p =>
                    p.Id == newParagraph.Id
                );
                if (existingParagraph is not null)
                {
                    // Update existing paragraph
                    existingParagraph.Update(
                        newParagraph.Title,
                        newParagraph.Content,
                        newParagraph.ContentType
                    );
                }
                else
                {
                    // Add new paragraph
                    this.paragraphs?.Add(newParagraph);
                }
            }

            // Remove paragraphs that are no longer in the new list
            if (this.paragraphs != null)
            {
                this.paragraphs.RemoveAll(p => newParagraphs.All(np => np.Id != p.Id));
            }
        }
    }
}
