using NorskApi.Domain.Common.Models;
using NorskApi.Domain.LocalExpressionAggregate.Enums;
using NorskApi.Domain.LocalExpressionAggregate.Events.DomainEvent;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

namespace NorskApi.Domain.LocalExpressionAggregate;

public sealed class LocalExpression : AggregateRoot<LocalExpressionId, Guid>
{
    public string Label { get; set; }
    public string? Description { get; set; }
    public string? MeaningInNorsk { get; set; }
    public string? MeaningInEnglish { get; set; }
    public LocalExpressionType LocalExpressionType { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private LocalExpression() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private LocalExpression(
        LocalExpressionId localExpressionId,
        string label,
        string? description,
        string? meaningInNorsk,
        string? meaningInEnglish,
        LocalExpressionType localExpressionType,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(localExpressionId)
    {
        this.Label = label;
        this.Description = description;
        this.MeaningInNorsk = meaningInNorsk;
        this.MeaningInEnglish = meaningInEnglish;
        this.LocalExpressionType = localExpressionType;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public static LocalExpression Create(
        string label,
        string? description,
        string? meaningInNorsk,
        string? meaningInEnglish,
        LocalExpressionType localExpressionType,
        DateTime createdAt,
        DateTime updatedAt
    )
    {
        LocalExpression localExpression = new LocalExpression(
            LocalExpressionId.CreateUnique(),
            label,
            description,
            meaningInNorsk,
            meaningInEnglish,
            LocalExpressionType.EVERYDAY_PHRASE,
            createdAt,
            updatedAt
        );

        localExpression.AddDomainEvent(new LocalExpressionCreatedDomainEvent(localExpression));

        return localExpression;
    }

    public void Update(
         LocalExpressionId localExpressionId,
        string label,
        string? description,
        string? meaningInNorsk,
        string? meaningInEnglish,
        LocalExpressionType localExpressionType,
        DateTime updatedAt
    )
    {
        this.Id = localExpressionId;
        this.Label = label;
        this.Description = description;
        this.MeaningInNorsk = meaningInNorsk;
        this.MeaningInEnglish = meaningInEnglish;
        this.LocalExpressionType = localExpressionType;
        this.UpdatedAt = updatedAt;

        this.AddDomainEvent(new LocalExpressionUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new LocalExpressionDeletedDomainEvent(this));
    }
}