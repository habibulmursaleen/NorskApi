using NorskApi.Domain.Common.Models;
using NorskApi.Domain.SubjunctionAggregate.Enums;
using NorskApi.Domain.SubjunctionAggregate.ValueObjects;

namespace NorskApi.Domain.SubjunctionAggregate;

public sealed class Subjunction : AggregateRoot<SubjunctionId, Guid>
{
    public string Label { get; set; }
    public SubjunctionType SubjunctionType { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Subjunction() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public Subjunction(SubjunctionId id, string label, SubjunctionType subjunctionType)
        : base(id)
    {
        this.Label = label;
        this.SubjunctionType = subjunctionType;
    }

    public static Subjunction Create(string label, SubjunctionType subjunctionType)
    {
        Subjunction subjunction = new Subjunction(
            SubjunctionId.CreateUnique(),
            label,
            subjunctionType
        );

        return subjunction;
    }

    public void Update(string label, SubjunctionType subjunctionType)
    {
        this.Label = label;
        this.SubjunctionType = subjunctionType;
    }

    public void Delete() { }
}
