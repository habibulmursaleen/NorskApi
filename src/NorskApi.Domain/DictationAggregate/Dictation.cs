using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.DictationAggregate.Events.DomainEvent;
using NorskApi.Domain.DictationAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Domain.DictationAggregate;

public sealed class Dictation : AggregateRoot<DictationId, Guid>
{
    public EssayId? EssayId { get; set; }
    public string Content { get; set; }
    public string? Answer { get; set; }
    public bool IsCompleted { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Dictation() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Dictation(
        DictationId DictationId,
        EssayId? essayId,
        string content,
        string? answer,
        bool isCompleted,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(DictationId)
    {
        this.EssayId = essayId;
        this.Content = content;
        this.Answer = answer;
        this.IsCompleted = isCompleted;
        this.DifficultyLevel = difficultyLevel;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public static Dictation Create(
        EssayId? essayId,
        string content,
        string? answer,
        bool isCompleted,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        Dictation dictation = new Dictation(
            DictationId.CreateUnique(),
            essayId,
            content,
            answer,
            isCompleted,
            DifficultyLevel.A1,
            createdAt,
            updatedAt
        );

        dictation.AddDomainEvent(new DictationCreatedDomainEvent(dictation));

        return dictation;
    }

    public void Update(
        EssayId? essayId,
        string content,
        string? answer,
        bool isCompleted,
        DifficultyLevel difficultyLevel,
        DateTime updatedAt
    )
    {
        this.EssayId = essayId;
        this.Content = content;
        this.Answer = answer;
        this.IsCompleted = isCompleted;
        this.DifficultyLevel = difficultyLevel;
        this.UpdatedAt = updatedAt;

        this.AddDomainEvent(new DictationUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new DictationDeletedDomainEvent(this));
    }

}


