using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.RoleplayAggregate.Events.DomainEvent;
using NorskApi.Domain.RoleplayAggregate.ValueObjects;

namespace NorskApi.Domain.RoleplayAggregate;

public sealed class Roleplay : AggregateRoot<RoleplayId, Guid>
{
    public EssayId EssayId { get; set; }
    public string Content { get; set; }
    public bool IsCompleted { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Roleplay() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Roleplay(
        RoleplayId roleplayId,
        EssayId essayId,
        string content,
        bool isCompleted,
        DifficultyLevel difficultyLevel
    )
        : base(roleplayId)
    {
        this.EssayId = essayId;
        this.Content = content;
        this.IsCompleted = isCompleted;
        this.DifficultyLevel = difficultyLevel;
    }

    public static Roleplay Create(
        EssayId essayId,
        string content,
        bool isCompleted,
        DifficultyLevel difficultyLevel
    )
    {
        Roleplay roleplay = new Roleplay(
            RoleplayId.CreateUnique(),
            essayId,
            content,
            isCompleted,
            difficultyLevel
        );

        roleplay.AddDomainEvent(new RoleplayCreatedDomainEvent(roleplay));

        return roleplay;
    }

    public void Update(
        EssayId essayId,
        string content,
        bool isCompleted,
        DifficultyLevel difficultyLevel
    )
    {
        this.EssayId = essayId;
        this.Content = content;
        this.IsCompleted = isCompleted;
        this.DifficultyLevel = difficultyLevel;

        this.AddDomainEvent(new RoleplayUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new RoleplayDeletedDomainEvent(this));
    }
}
