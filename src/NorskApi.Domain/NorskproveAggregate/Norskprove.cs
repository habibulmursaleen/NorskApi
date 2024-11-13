using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.DictationAggregate.ValueObjects;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.NorskproveAggregate.Events.DomainEvent;
using NorskApi.Domain.NorskproveAggregate.ValueObjects;
using NorskApi.Domain.QuestionAggregate.ValueObjects;
using NorskApi.Domain.TagAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate.ValueObjects;

namespace NorskApi.Domain.NorskproveAggregate;

public sealed class Norskprove : AggregateRoot<NorskproveId, Guid>
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsSaved { get; set; }
    public double Progress { get; set; }
    public double TimeLimit { get; set; }
    public double EstimatedCompletionTime { get; set; }
    public double Attempts { get; set; }
    public double MaxScore { get; set; }
    public Status Status { get; set; } // Enum: ACTIVE, INACTIVE
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1, C2
    private readonly List<TagId> norskproveTagIds = [];
    private readonly List<QuestionId> speakingContentIds = [];
    private readonly List<DictationId> listeningContentIds = [];
    private readonly List<EssayId> readingContentIds = [];
    private readonly List<DiscussionId> writingContentIds = [];
    private readonly List<TaskWorkId> additionalGrammarTaskIds = [];
    public IReadOnlyCollection<TagId> NorskproveTagIds => this.norskproveTagIds;
    public IReadOnlyCollection<QuestionId> SpeakingContentIds => this.speakingContentIds;
    public IReadOnlyCollection<DictationId> ListeningContentIds => this.listeningContentIds;
    public IReadOnlyCollection<EssayId> ReadingContentIds => this.readingContentIds;
    public IReadOnlyCollection<DiscussionId> WritingContentIds => this.writingContentIds;
    public IReadOnlyCollection<TaskWorkId> AdditionalGrammarTaskIds =>
        this.additionalGrammarTaskIds;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Norskprove() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Norskprove(
        NorskproveId norskproveId,
        string Title,
        string? Description,
        bool IsCompleted,
        bool IsSaved,
        double Progress,
        double TimeLimit,
        double EstimatedCompletionTime,
        double Attempts,
        double MaxScore,
        Status Status,
        DifficultyLevel DifficultyLevel,
        List<TagId> NorskproveTagIds,
        List<QuestionId> SpeakingContentIds,
        List<DictationId> ListeningContentIds,
        List<EssayId> ReadingContentIds,
        List<DiscussionId> WritingContentIds,
        List<TaskWorkId> AdditionalGrammarTaskIds
    )
        : base(norskproveId)
    {
        this.Title = Title;
        this.Description = Description;
        this.IsCompleted = IsCompleted;
        this.IsSaved = IsSaved;
        this.Progress = Progress;
        this.TimeLimit = TimeLimit;
        this.EstimatedCompletionTime = EstimatedCompletionTime;
        this.Attempts = Attempts;
        this.MaxScore = MaxScore;
        this.Status = Status;
        this.DifficultyLevel = DifficultyLevel;
        this.norskproveTagIds.AddRange(NorskproveTagIds);
        this.speakingContentIds.AddRange(SpeakingContentIds);
        this.listeningContentIds.AddRange(ListeningContentIds);
        this.readingContentIds.AddRange(ReadingContentIds);
        this.writingContentIds.AddRange(WritingContentIds);
        this.additionalGrammarTaskIds.AddRange(AdditionalGrammarTaskIds);
    }

    public static Norskprove Create(
        string Title,
        string? Description,
        bool IsCompleted,
        bool IsSaved,
        double Progress,
        double TimeLimit,
        double EstimatedCompletionTime,
        double Attempts,
        double MaxScore,
        Status Status,
        DifficultyLevel DifficultyLevel,
        List<TagId> NorskproveTagIds,
        List<QuestionId> SpeakingContentIds,
        List<DictationId> ListeningContentIds,
        List<EssayId> ReadingContentIds,
        List<DiscussionId> WritingContentIds,
        List<TaskWorkId> AdditionalGrammarTaskIds
    )
    {
        Norskprove norskprove = new Norskprove(
            NorskproveId.CreateUnique(),
            Title,
            Description,
            IsCompleted,
            IsSaved,
            Progress,
            TimeLimit,
            EstimatedCompletionTime,
            Attempts,
            MaxScore,
            Status,
            DifficultyLevel,
            NorskproveTagIds,
            SpeakingContentIds,
            ListeningContentIds,
            ReadingContentIds,
            WritingContentIds,
            AdditionalGrammarTaskIds
        );

        norskprove.AddDomainEvent(new NorskproveCreatedDomainEvent(norskprove));

        return norskprove;
    }

    public void Update(
        string Title,
        string? Description,
        bool IsCompleted,
        bool IsSaved,
        double Progress,
        double TimeLimit,
        double EstimatedCompletionTime,
        double Attempts,
        double MaxScore,
        Status Status,
        DifficultyLevel DifficultyLevel,
        List<TagId> NorskproveTagIds,
        List<QuestionId> SpeakingContentIds,
        List<DictationId> ListeningContentIds,
        List<EssayId> ReadingContentIds,
        List<DiscussionId> WritingContentIds,
        List<TaskWorkId> AdditionalGrammarTaskIds
    )
    {
        this.Title = Title;
        this.Description = Description;
        this.IsCompleted = IsCompleted;
        this.IsSaved = IsSaved;
        this.Progress = Progress;
        this.TimeLimit = TimeLimit;
        this.EstimatedCompletionTime = EstimatedCompletionTime;
        this.Attempts = Attempts;
        this.MaxScore = MaxScore;
        this.Status = Status;
        this.DifficultyLevel = DifficultyLevel;
        this.norskproveTagIds.Clear();
        this.norskproveTagIds.AddRange(NorskproveTagIds);
        this.speakingContentIds.Clear();
        this.speakingContentIds.AddRange(SpeakingContentIds);
        this.listeningContentIds.Clear();
        this.listeningContentIds.AddRange(ListeningContentIds);
        this.readingContentIds.Clear();
        this.readingContentIds.AddRange(ReadingContentIds);
        this.writingContentIds.Clear();
        this.writingContentIds.AddRange(WritingContentIds);
        this.additionalGrammarTaskIds.Clear();
        this.additionalGrammarTaskIds.AddRange(AdditionalGrammarTaskIds);

        this.AddDomainEvent(new NorskproveUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new NorskproveDeletedDomainEvent(this));
    }
}
