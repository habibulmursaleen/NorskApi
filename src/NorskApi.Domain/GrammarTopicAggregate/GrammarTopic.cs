using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammarTopicAggregate.Events.DomainEvent;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

namespace NorskApi.Domain.GrammarTopicAggregate;

public sealed class GrammarTopic : AggregateRoot<TopicId, Guid>
{
    public string Label { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; } // Enum: ACTIVE, INACTIVE
    public double Chapter { get; set; }
    public double ModuleCount { get; set; }
    public double Progress { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsSaved { get; set; }
    public List<string>? Tags { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private GrammarTopic() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private GrammarTopic(
        TopicId topicId,
        string label,
        string? description,
        Status status,
        double chapter,
        double moduleCount,
        double progress,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel
    )
        : base(topicId)
    {
        this.Label = label;
        this.Description = description;
        this.Status = status;
        this.Chapter = chapter;
        this.ModuleCount = moduleCount;
        this.Progress = progress;
        this.IsCompleted = isCompleted;
        this.IsSaved = isSaved;
        this.Tags = tags;
        this.DifficultyLevel = difficultyLevel;
    }

    public static GrammarTopic Create(
        string label,
        string? description,
        Status status,
        double chapter,
        double moduleCount,
        double progress,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel
    )
    {
        GrammarTopic grammarTopic = new GrammarTopic(
            TopicId.CreateUnique(),
            label,
            description,
            status,
            chapter,
            moduleCount,
            progress,
            isCompleted,
            isSaved,
            tags,
            difficultyLevel
        );

        grammarTopic.AddDomainEvent(new GrammarTopicCreatedDomainEvent(grammarTopic));

        return grammarTopic;
    }

    public void Update(
        string label,
        string? description,
        Status status,
        double chapter,
        double moduleCount,
        double progress,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel
    )
    {
        this.Label = label;
        this.Description = description;
        this.Status = status;
        this.Chapter = chapter;
        this.ModuleCount = moduleCount;
        this.Progress = progress;
        this.IsCompleted = isCompleted;
        this.IsSaved = isSaved;
        this.Tags = tags;
        this.DifficultyLevel = difficultyLevel;

        this.AddDomainEvent(new GrammarTopicUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new GrammarTopicDeletedDomainEvent(this));
    }
}
