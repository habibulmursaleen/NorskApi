using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.DiscussionAggregate.Events.DomainEvent;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Domain.DiscussionAggregate;
public sealed class Discussion : AggregateRoot<DiscussionId, Guid>
{
    public EssayId? EssayId { get; set; }
    public string Title { get; set; }
    public string DiscussionEssays { get; set; }
    public bool IsCompleted { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public string? Note { get; set; } // User input
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Discussion() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Discussion(
        DiscussionId discussionId,
        EssayId? essayId,
        string title,
        string discussionEssays,
        bool isCompleted,
        DifficultyLevel difficultyLevel,
        string? note,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(discussionId)
    {
        this.EssayId = essayId;
        this.Title = title;
        this.DiscussionEssays = discussionEssays;
        this.IsCompleted = isCompleted;
        this.DifficultyLevel = difficultyLevel;
        this.Note = note;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public static Discussion Create(
        EssayId? essayId,
        string title,
        string discussionEssays,
        bool isCompleted,
        DifficultyLevel difficultyLevel,
        string? note,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        Discussion discussion = new Discussion(
            DiscussionId.CreateUnique(),
            essayId,
            title,
            discussionEssays,
            isCompleted,
            DifficultyLevel.A1,
            note,
            createdAt,
            updatedAt
        );

        discussion.AddDomainEvent(new DiscussionCreatedDomainEvent(discussion));

        return discussion;
    }

    public void Update(
        EssayId? essayId,
        string title,
        string discussionEssays,
        bool isCompleted,
        DifficultyLevel difficultyLevel,
        string? note,
        DateTime updatedAt
    )
    {
        this.EssayId = essayId;
        this.Title = title;
        this.DiscussionEssays = discussionEssays;
        this.IsCompleted = isCompleted;
        this.DifficultyLevel = difficultyLevel;
        this.Note = note;
        this.UpdatedAt = updatedAt;

        this.AddDomainEvent(new DiscussionUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new DiscussionDeletedDomainEvent(this));
    }
}