using NorskApi.Domain.SubjunctionAggregate;
using NorskApi.Domain.SubjunctionAggregate.ValueObjects;
using NorskApi.Domain.SubjunctionAgreegate;

namespace NorskApi.Application.Common.Interfaces.Persistance;

public interface ISubjunctionRepository
{
    Task<List<Subjunction>> GetAll(CancellationToken cancellationToken);
}
