using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate.Events.DomainEvent;
using NorskApi.Domain.TaskWorkAggregate.ValueObjects;

namespace NorskApi.Domain.TaskWorkAggregate;

public sealed class TaskWork : AggregateRoot<TaskWorkId, Guid>
{
    public TopicId TopicId { get; set; }
    public string? Logo { get; set; }
    public string Label { get; set; }
    public string? TaskPointer { get; set; }
    public bool IsCompleted { get; set; }
    public string? Answer { get; set; } // User input
    public string? Comments { get; set; }
    public string? AdditionalInfo { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private TaskWork() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private TaskWork(
        TaskWorkId taskWorkId,
        TopicId topicId,
        string? logo,
        string label,
        string? taskPointer,
        bool isCompleted,
        string? answer,
        string? comments,
        string? additionalInfo,
        DifficultyLevel difficultyLevel
    )
        : base(taskWorkId)
    {
        this.TopicId = topicId;
        this.Logo = logo;
        this.Label = label;
        this.TaskPointer = taskPointer;
        this.IsCompleted = isCompleted;
        this.Answer = answer;
        this.Comments = comments;
        this.AdditionalInfo = additionalInfo;
        this.DifficultyLevel = difficultyLevel;
    }

    public static TaskWork Create(
        TopicId topicId,
        string? logo,
        string label,
        string? taskPointer,
        bool isCompleted,
        string? answer,
        string? comments,
        string? additionalInfo,
        DifficultyLevel difficultyLevel
    )
    {
        TaskWork taskWork = new TaskWork(
            TaskWorkId.CreateUnique(),
            topicId,
            logo,
            label,
            taskPointer,
            isCompleted,
            answer,
            comments,
            additionalInfo,
            difficultyLevel
        );

        taskWork.AddDomainEvent(new TaskWorkCreatedDomainEvent(taskWork));

        return taskWork;
    }

    public void Update(
        TopicId topicId,
        string? logo,
        string label,
        string? taskPointer,
        bool isCompleted,
        string? answer,
        string? comments,
        string? additionalInfo,
        DifficultyLevel difficultyLevel
    )
    {
        this.TopicId = topicId;
        this.Logo = logo;
        this.Label = label;
        this.TaskPointer = taskPointer;
        this.IsCompleted = isCompleted;
        this.Answer = answer;
        this.Comments = comments;
        this.AdditionalInfo = additionalInfo;
        this.DifficultyLevel = difficultyLevel;

        this.AddDomainEvent(new TaskWorkUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new TaskWorkDeletedDomainEvent(this));
    }
}
