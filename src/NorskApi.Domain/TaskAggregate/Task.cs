using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TaskAggregate.Events.DomainEvent;
using NorskApi.Domain.TaskAggregate.ValueObjects;

namespace NorskApi.Domain.TaskAggregate;

public sealed class Task : AggregateRoot<TaskId, Guid>
{
    public TopicId? TopicId { get; set; }
    public string? Logo { get; set; }
    public string Label { get; set; }
    public string? TaskPointer { get; set; }
    public string? Answer { get; set; } // User input
    public string? Comments { get; set; }
    public string? AdditionalInfo { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Task() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Task(
        TaskId taskId,
        TopicId topicId,
        string? logo,
        string label,
        string? taskPointer,
        string? answer,
        string? comments,
        string? additionalInfo,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(taskId)
    {
        this.TopicId = topicId;
        this.Logo = logo;
        this.Label = label;
        this.TaskPointer = taskPointer;
        this.Answer = answer;
        this.Comments = comments;
        this.AdditionalInfo = additionalInfo;
        this.DifficultyLevel = difficultyLevel;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public static Task Create(
        TopicId topicId,
        string? logo,
        string label,
        string? taskPointer,
        string? answer,
        string? comments,
        string? additionalInfo,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        Task task = new Task(
            TaskId.CreateUnique(),
            topicId,
            logo,
            label,
            taskPointer,
            answer,
            comments,
            additionalInfo,
            difficultyLevel,
            createdAt,
            updatedAt
        );

        task.AddDomainEvent(new TaskCreatedDomainEvent(task));

        return task;
    }

    public void Update(
        TopicId topicId,
        string? logo,
        string label,
        string? taskPointer,
        string? answer,
        string? comments,
        string? additionalInfo,
        DifficultyLevel difficultyLevel,
        DateTime updatedAt
    )
    {
        this.TopicId = topicId;
        this.Logo = logo;
        this.Label = label;
        this.TaskPointer = taskPointer;
        this.Answer = answer;
        this.Comments = comments;
        this.AdditionalInfo = additionalInfo;
        this.DifficultyLevel = difficultyLevel;
        this.UpdatedAt = updatedAt;

        this.AddDomainEvent(new TaskUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new TaskDeletedDomainEvent(this));
    }
}