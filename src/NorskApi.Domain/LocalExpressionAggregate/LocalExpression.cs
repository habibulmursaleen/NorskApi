using NorskApi.Domain.Common.Models;
using NorskApi.Domain.LocalExpressionAggregate.Enums;
using NorskApi.Domain.LocalExpressionAggregate.Events.DomainEvent;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

namespace NorskApi.Domain.LocalExpressionAggregate;

public sealed class LocalExpression : AggregateRoot<LocalExpressionId, Guid>
{
    public string Label { get; set; }
    public string Description { get; set; } = string.Empty;
    public string MeaningInNorsk { get; set; } = string.Empty;
    public string MeaningInEnglish { get; set; } = string.Empty;
    public LocalExpressionType LocalExpressionType { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private LocalExpression() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private LocalExpression(
        LocalExpressionId localExpressionId,
        string label,
        string? description,
        string? meaningInNorsk,
        string? meaningInEnglish,
        LocalExpressionType localExpressionType
    ) : base(localExpressionId)
    {
        this.Label = label;
        this.Description = description ?? string.Empty;
        this.MeaningInNorsk = meaningInNorsk ?? string.Empty;
        this.MeaningInEnglish = meaningInEnglish ?? string.Empty;
        this.LocalExpressionType = localExpressionType;
    }

    public static LocalExpression Create(
        string label,
        string? description,
        string? meaningInNorsk,
        string? meaningInEnglish,
        LocalExpressionType localExpressionType
    )
    {
        LocalExpression localExpression = new LocalExpression(
            LocalExpressionId.CreateUnique(),
            label,
            description,
            meaningInNorsk,
            meaningInEnglish,
            localExpressionType
        );

        localExpression.AddDomainEvent(new LocalExpressionCreatedDomainEvent(localExpression));

        return localExpression;
    }

    public void Update(
        string label,
        string? description,
        string? meaningInNorsk,
        string? meaningInEnglish,
        LocalExpressionType localExpressionType
    )
    {
        this.Label = label;
        this.Description = description ?? string.Empty;
        this.MeaningInNorsk = meaningInNorsk ?? string.Empty;
        this.MeaningInEnglish = meaningInEnglish ?? string.Empty;
        this.LocalExpressionType = localExpressionType;

        this.AddDomainEvent(new LocalExpressionUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new LocalExpressionDeletedDomainEvent(this));
    }
}