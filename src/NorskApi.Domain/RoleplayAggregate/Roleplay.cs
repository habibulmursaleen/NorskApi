using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.RoleplayAggregate.Events.DomainEvent;
using NorskApi.Domain.RoleplayAggregate.ValueObjects;

namespace NorskApi.Domain.RoleplayAggregate;

public sealed class Roleplay : AggregateRoot<RoleplayId, Guid>
{
    public EssayId? EssayId { get; set; }
    public string Content { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Roleplay() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Roleplay(
        RoleplayId roleplayId,
        EssayId? essayId,
        string content,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(roleplayId)
    {
        this.EssayId = essayId;
        this.Content = content;
        this.DifficultyLevel = difficultyLevel;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public static Roleplay Create(
        EssayId? essayId,
        string content,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        Roleplay roleplay = new Roleplay(
            RoleplayId.CreateUnique(),
            essayId,
            content,
            DifficultyLevel.A1,
            createdAt,
            updatedAt
        );

        roleplay.AddDomainEvent(new RoleplayCreatedDomainEvent(roleplay));

        return roleplay;
    }

    public void Update(
        EssayId? essayId,
        string content,
        DifficultyLevel difficultyLevel,
        DateTime updatedAt
    )
    {
        this.EssayId = essayId;
        this.Content = content;
        this.DifficultyLevel = difficultyLevel;
        this.UpdatedAt = updatedAt;

        this.AddDomainEvent(new RoleplayUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new RoleplayDeletedDomainEvent(this));
    }
}