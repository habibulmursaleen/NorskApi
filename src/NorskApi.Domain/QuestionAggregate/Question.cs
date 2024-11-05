using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.QuestionAggregate.Events.DomainEvent;
using NorskApi.Domain.QuestionAggregate.ValueObjects;

namespace NorskApi.Domain.QuestionAggregate;

public sealed class Question : AggregateRoot<QuestionId, Guid>
{
    public EssayId EssayId { get; set; }
    public string Label { get; set; }
    public string? Answer { get; set; }
    public bool IsCompleted { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Question() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Question(
        QuestionId questionId,
        EssayId essayId,
        string label,
        string? answer,
        bool isCompleted,
        DifficultyLevel difficultyLevel
    )
        : base(questionId)
    {
        this.EssayId = essayId;
        this.Label = label;
        this.Answer = answer;
        this.IsCompleted = isCompleted;
        this.DifficultyLevel = difficultyLevel;
    }

    public static Question Create(
        EssayId essayId,
        string label,
        string? answer,
        bool isCompleted,
        DifficultyLevel difficultyLevel
    )
    {
        Question question = new Question(
            QuestionId.CreateUnique(),
            essayId,
            label,
            answer,
            isCompleted,
            difficultyLevel
        );

        question.AddDomainEvent(new QuestionCreatedDomainEvent(question));

        return question;
    }

    public void Update(
        EssayId essayId,
        string label,
        string? answer,
        bool isCompleted,
        DifficultyLevel difficultyLevel
    )
    {
        this.EssayId = essayId;
        this.Label = label;
        this.Answer = answer;
        this.IsCompleted = isCompleted;
        this.DifficultyLevel = difficultyLevel;
    }

    public void Delete()
    {
        this.AddDomainEvent(new QuestionDeletedDomainEvent(this));
    }
}
