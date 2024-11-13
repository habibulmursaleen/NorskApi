using NorskApi.Domain.ActivityAggregate.Enums;
using NorskApi.Domain.ActivityAggregate.Events.DomainEvent;
using NorskApi.Domain.ActivityAggregate.ValueObjects;
using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.ActivityAggregate;

public sealed class Activity : AggregateRoot<ActivityId, Guid>
{
    public string Label { get; set; }
    public ActivityType ActivityType { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Activity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Activity(ActivityId ActivityId, string label, ActivityType activityType)
        : base(ActivityId)
    {
        this.Label = label;
        this.ActivityType = activityType;
    }

    public static Activity Create(string label, ActivityType activityType)
    {
        Activity activity = new Activity(ActivityId.CreateUnique(), label, activityType);

        activity.AddDomainEvent(new ActivityCreatedDomainEvent(activity));

        return activity;
    }

    public void Update(string label, ActivityType activityType)
    {
        this.Label = label;
        this.ActivityType = activityType;

        this.AddDomainEvent(new ActivityUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new ActivityDeletedDomainEvent(this));
    }
}
