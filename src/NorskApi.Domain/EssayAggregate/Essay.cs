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
    public decimal Progress { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsSaved { get; set; }
    public Status Status { get; set; } // Enum: ACTIVE, INACTIVE
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<string>? Activities { get; set; } // Enum: Paragraphs, Discussions, Quizzes, Words, Roleplay
    public List<string>? Tags { get; set; }
    public List<TopicId>? RelatedGrammarTopicIds { get; set; }
    private readonly List<Paragraph>? paragraphs = new();
    private readonly List<AdditionalContent>? additionalContents = new();
    public IReadOnlyCollection<Paragraph> Paragraphs => this.Paragraphs;
    public IReadOnlyCollection<AdditionalContent> AdditionalContents => this.AdditionalContents;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Essay() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Essay(
        EssayId id,
        string? logo,
        string label,
        string? description,
        Status status,
        int progress,
        List<string>? activities,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt,
        List<Paragraph>? paragraphs,
        List<AdditionalContent>? additionalContents,
        List<TopicId>? relatedGrammarTopicIds
    ) : base(id)
    {
        this.Id = id;
        this.Logo = logo;
        this.Label = label;
        this.Description = description;
        this.Status = status;
        this.Progress = progress;
        this.Activities = activities;
        this.IsCompleted = isCompleted;
        this.IsSaved = isSaved;
        this.Tags = tags;
        this.DifficultyLevel = difficultyLevel;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
        this.paragraphs = paragraphs;
        this.additionalContents = additionalContents;
        this.RelatedGrammarTopicIds = relatedGrammarTopicIds;
    }

    public static Essay Create(
        string? logo,
        string label,
        string? description,
        Status status,
        int progress,
        List<string>? activities,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt,
        List<Paragraph>? paragraphs,
        List<AdditionalContent>? additionalContents,
        List<TopicId>? relatedGrammarTopicIds
    )
    {
        Essay essay = new Essay(
            EssayId.CreateUnique(),
            logo,
            label,
            description,
            Status.ACTIVE,
            progress,
            activities,
            isCompleted,
            isSaved,
            tags,
            DifficultyLevel.A1,
            createdAt,
            updatedAt,
            paragraphs,
            additionalContents,
            relatedGrammarTopicIds
        );

        essay.AddDomainEvent(new EssayCreatedDomainEvent(essay));

        return essay;
    }

    public void Update(
        string? logo,
        string label,
        string? description,
        Status status,
        int progress,
        List<string>? activities,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel,
        DateTime updatedAt,
        List<Paragraph>? paragraphs,
        List<AdditionalContent>? additionalContents,
        List<TopicId>? relatedGrammarTopicIds
    )
    {
        this.Logo = logo;
        this.Label = label;
        this.Description = description;
        this.Status = status;
        this.Progress = progress;
        this.Activities = activities;
        this.IsCompleted = isCompleted;
        this.IsSaved = isSaved;
        this.Tags = tags;
        this.DifficultyLevel = difficultyLevel;
        this.UpdatedAt = updatedAt;
        this.RelatedGrammarTopicIds = relatedGrammarTopicIds;

        UpdateParagraphs(paragraphs);
        UpdateAdditionalContents(additionalContents);

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
                var existingParagraph = this.paragraphs?.FirstOrDefault(p => p.Id == newParagraph.Id);
                if (existingParagraph is not null)
                {
                    // Update existing paragraph
                    existingParagraph.Update(newParagraph.EssayId, newParagraph.Title, newParagraph.Content, newParagraph.UpdatedAt);
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

    private void UpdateAdditionalContents(List<AdditionalContent>? newAdditionalContents)
    {
        if (newAdditionalContents is not null)
        {
            // Update existing additional contents or add new ones
            foreach (var newAdditionalContent in newAdditionalContents)
            {
                var existingAdditionalContent = this.additionalContents?.FirstOrDefault(ac => ac.Id == newAdditionalContent.Id);
                if (existingAdditionalContent is not null)
                {
                    // Update existing additional content
                    existingAdditionalContent.Update(newAdditionalContent.EssayId, newAdditionalContent.Content, newAdditionalContent.UpdatedAt);
                }
                else
                {
                    // Add new additional content
                    this.additionalContents?.Add(newAdditionalContent);
                }
            }
        }
    }
}
