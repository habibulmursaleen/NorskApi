using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.PodcastAggregate.Events.DomainEvent;
using NorskApi.Domain.PodcastAggregate.ValueObjects;

namespace NorskApi.Domain.PodcastAggregate;

public sealed class Podcast : AggregateRoot<PodcastId, Guid>
{
    public EssayId? EssayId { get; set; }
    public string Label { get; set; }
    public string? Descriptions { get; set; }
    public string Logo { get; set; }
    public string Url { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsFeatured { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Podcast() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Podcast(
        PodcastId podcastId,
        EssayId? essayId,
        string label,
        string? descriptions,
        string logo,
        string url,
        bool isCompleted,
        bool isFeatured,
        DifficultyLevel difficultyLevel
    )
        : base(podcastId)
    {
        this.EssayId = essayId;
        this.Label = label;
        this.Descriptions = descriptions;
        this.Logo = logo;
        this.Url = url;
        this.IsCompleted = isCompleted;
        this.IsFeatured = isFeatured;
        this.DifficultyLevel = difficultyLevel;
    }

    public static Podcast Create(
        EssayId? essayId,
        string label,
        string? descriptions,
        string logo,
        string url,
        bool isCompleted,
        bool isFeatured,
        DifficultyLevel difficultyLevel
    )
    {
        Podcast podcast = new Podcast(
            PodcastId.CreateUnique(),
            essayId,
            label,
            descriptions,
            logo,
            url,
            isCompleted,
            isFeatured,
            difficultyLevel
        );

        podcast.AddDomainEvent(new PodcastCreatedDomainEvent(podcast));

        return podcast;
    }

    public void Update(
        EssayId? essayId,
        string label,
        string? descriptions,
        string logo,
        string url,
        bool isCompleted,
        bool isFeatured,
        DifficultyLevel difficultyLevel
    )
    {
        this.EssayId = essayId;
        this.Label = label;
        this.Descriptions = descriptions;
        this.Logo = logo;
        this.Url = url;
        this.IsCompleted = isCompleted;
        this.IsFeatured = isFeatured;
        this.DifficultyLevel = difficultyLevel;

        this.AddDomainEvent(new PodcastUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new PodcastDeletedDomainEvent(this));
    }
}
