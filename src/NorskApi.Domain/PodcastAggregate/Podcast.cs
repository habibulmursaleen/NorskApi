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
    public string Link { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Podcast() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Podcast(
        PodcastId podcastId,
        EssayId? essayId,
        string label,
        string? descriptions,
        string logo,
        string link,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(podcastId)
    {
        this.EssayId = essayId;
        this.Label = label;
        this.Descriptions = descriptions;
        this.Logo = logo;
        this.Link = link;
        this.DifficultyLevel = difficultyLevel;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public static Podcast Create(
        EssayId? essayId,
        string label,
        string? descriptions,
        string logo,
        string link,
        DifficultyLevel difficultyLevel,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        Podcast podcast = new Podcast(
            PodcastId.CreateUnique(),
            essayId,
            label,
            descriptions,
            logo,
            link,
            DifficultyLevel.A1,
            createdAt,
            updatedAt
        );

        podcast.AddDomainEvent(new PodcastCreatedDomainEvent(podcast));

        return podcast;
    }

    public void Update(
        EssayId? essayId,
        string label,
        string? descriptions,
        string logo,
        string link,
        DifficultyLevel difficultyLevel,
        DateTime updatedAt
    )
    {
        this.EssayId = essayId;
        this.Label = label;
        this.Descriptions = descriptions;
        this.Logo = logo;
        this.Link = link;
        this.DifficultyLevel = difficultyLevel;
        this.UpdatedAt = updatedAt;

        this.AddDomainEvent(new PodcastUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new PodcastDeletedDomainEvent(this));
    }

}