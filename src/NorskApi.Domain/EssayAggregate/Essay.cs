using NorskApi.Domain.ActivityAggregate.ValueObjects;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.Entities.EssayAggregate.Events.DomainEvent;
using NorskApi.Domain.EssayAggregate.Entities;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TagAggregate.ValueObjects;

public sealed class Essay : AggregateRoot<EssayId, Guid>
{
    public string? Logo { get; set; } // URL or Base64 string
    public string Label { get; set; }
    public string? Description { get; set; }
    public double Progress { get; set; }
    public Status Status { get; set; } // Enum: ACTIVE, INACTIVE
    public string Notes { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsSaved { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public List<ActivityId> EssayActivityIds { get; set; }
    public List<TagId> EssayTagIds { get; set; }
    public List<TopicId> EssayRelatedGrammarTopicIds { get; set; }
    private readonly List<Paragraph> paragraphs = [];
    private readonly List<Roleplay> roleplays = [];
    public IReadOnlyCollection<Paragraph> Paragraphs => this.paragraphs;
    public IReadOnlyCollection<Roleplay> Roleplays => this.roleplays;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Essay() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Essay(
        EssayId id,
        string? logo,
        string label,
        string? description,
        double progress,
        Status status,
        string notes,
        bool isCompleted,
        bool isSaved,
        DifficultyLevel difficultyLevel,
        List<ActivityId> essayActivityIds,
        List<TagId> essayTagIds,
        List<TopicId> EssayRelatedGrammarTopicIds,
        List<Paragraph> paragraphs,
        List<Roleplay> roleplays
    )
        : base(id)
    {
        this.Id = id;
        this.Logo = logo;
        this.Label = label;
        this.Description = description;
        this.Progress = progress;
        this.Status = status;
        this.Notes = notes;
        this.IsCompleted = isCompleted;
        this.IsSaved = isSaved;
        this.DifficultyLevel = difficultyLevel;
        this.EssayActivityIds = essayActivityIds;
        this.EssayTagIds = essayTagIds;
        this.EssayRelatedGrammarTopicIds = EssayRelatedGrammarTopicIds;
        this.paragraphs = paragraphs;
        this.roleplays = roleplays;
    }

    public static Essay Create(
        string? logo,
        string label,
        string? description,
        double progress,
        Status status,
        string notes,
        bool isCompleted,
        bool isSaved,
        DifficultyLevel difficultyLevel,
        List<ActivityId> essayActivityIds,
        List<TagId> essayTagIds,
        List<TopicId> EssayRelatedGrammarTopicIds,
        List<Paragraph> paragraphs,
        List<Roleplay> roleplays
    )
    {
        Essay essay =
            new(
                EssayId.CreateUnique(),
                logo,
                label,
                description,
                progress,
                status,
                notes,
                isCompleted,
                isSaved,
                difficultyLevel,
                essayActivityIds,
                essayTagIds,
                EssayRelatedGrammarTopicIds,
                paragraphs,
                roleplays
            );

        essay.AddDomainEvent(new EssayCreatedDomainEvent(essay));

        return essay;
    }

    public void Update(
        string? logo,
        string label,
        string? description,
        double progress,
        Status status,
        string notes,
        bool isCompleted,
        bool isSaved,
        DifficultyLevel difficultyLevel,
        List<ActivityId> essayActivityIds,
        List<TagId> essayTagIds,
        List<TopicId> EssayRelatedGrammarTopicIds,
        List<Paragraph> paragraphs,
        List<Roleplay> roleplays
    )
    {
        this.Logo = logo;
        this.Label = label;
        this.Description = description;
        this.Progress = progress;
        this.Status = status;
        this.Notes = notes;
        this.IsCompleted = isCompleted;
        this.IsSaved = isSaved;
        this.DifficultyLevel = difficultyLevel;
        this.EssayActivityIds = essayActivityIds;
        this.EssayTagIds = essayTagIds;
        this.EssayRelatedGrammarTopicIds = EssayRelatedGrammarTopicIds;

        UpdateParagraphs(paragraphs);
        UpdateRoleplays(roleplays);
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

    private void UpdateRoleplays(List<Roleplay>? newRoleplays)
    {
        if (newRoleplays is not null)
        {
            foreach (var newRoleplay in newRoleplays)
            {
                var existingRoleplay = this.roleplays?.FirstOrDefault(p => p.Id == newRoleplay.Id);
                if (existingRoleplay is not null)
                {
                    // Update existing paragraph
                    existingRoleplay.Update(newRoleplay.Content, newRoleplay.IsCompleted);
                }
                else
                {
                    // Add new paragraph
                    this.roleplays?.Add(newRoleplay);
                }
            }

            // Remove paragraphs that are no longer in the new list
            if (this.roleplays != null)
            {
                this.roleplays.RemoveAll(p => newRoleplays.All(np => np.Id != p.Id));
            }
        }
    }
}
