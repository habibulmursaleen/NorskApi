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
    public int Chapter { get; set; }
    public int ModuleCount { get; set; }
    public int Progress { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsSaved { get; set; }
    public List<string>? Tags { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private GrammarTopic() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private GrammarTopic(
        TopicId topicId,
        string label,
        string? description,
        Status status,
        int chapter,
        int moduleCount,
        int progress,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(topicId)
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
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public static GrammarTopic Create(
        string label,
        string? description,
        Status status,
        int chapter,
        int moduleCount,
        int progress,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt
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
            DifficultyLevel.A1,
            createdAt,
            updatedAt
        );

        grammarTopic.AddDomainEvent(new GrammarTopicCreatedDomainEvent(grammarTopic));

        return grammarTopic;
    }

    public void Update(
        string label,
        string? description,
        Status status,
        int chapter,
        int moduleCount,
        int progress,
        bool isCompleted,
        bool isSaved,
        List<string>? tags,
        DifficultyLevel difficultyLevel,
        DateTime updatedAt
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
        this.UpdatedAt = updatedAt;

        this.AddDomainEvent(new GrammarTopicUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new GrammarTopicDeletedDomainEvent(this));
    }
}

