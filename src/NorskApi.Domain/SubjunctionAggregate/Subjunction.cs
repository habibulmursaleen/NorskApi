using NorskApi.Domain.Common.Models;
using NorskApi.Domain.SubjunctionAggregate.Events.DomainEvent;
using NorskApi.Domain.SubjunctionAggregate.ValueObjects;

namespace NorskApi.Domain.SubjunctionAgreegate;

public sealed class Subjunction : AggregateRoot<SubjunctionId, Guid>
{
    public List<string>? Time { get; set; }
    public List<string>? Arsak { get; set; }
    public List<string>? Hensikt { get; set; }
    public List<string>? Betingelse { get; set; }
    public List<string>? Motsetning { get; set; }

    private Subjunction() { }

    public Subjunction(SubjunctionId id, List<string>? time, List<string>? arsak, List<string>? hensikt, List<string>? betingelse, List<string>? motsetning)
        : base(id)
    {
        this.Time = time;
        this.Arsak = arsak;
        this.Hensikt = hensikt;
        this.Betingelse = betingelse;
        this.Motsetning = motsetning;
    }

    public static Subjunction Create(
        List<string>? time,
        List<string>? arsak,
        List<string>? hensikt,
        List<string>? betingelse,
        List<string>? motsetning
    )
    {
        Subjunction subjunction = new Subjunction(
            SubjunctionId.CreateUnique(),
            time,
            arsak,
            hensikt,
            betingelse,
            motsetning
        );

        subjunction.AddDomainEvent(new SubjunctionCreatedDomainEvent(subjunction));

        return subjunction;
    }

    public void Update(
        List<string>? time,
        List<string>? arsak,
        List<string>? hensikt,
        List<string>? betingelse,
        List<string>? motsetning
    )
    {
        this.Time = time;
        this.Arsak = arsak;
        this.Hensikt = hensikt;
        this.Betingelse = betingelse;
        this.Motsetning = motsetning;

        this.AddDomainEvent(new SubjunctionUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new SubjunctionDeletedDomainEvent(this));
    }
}