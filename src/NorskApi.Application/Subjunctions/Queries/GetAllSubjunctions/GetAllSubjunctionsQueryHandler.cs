using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Subjunctions.Models;
using NorskApi.Application.Subjunctions.Queries.GetAllSubjunctions;

public class GetAllSubjunctionsQueryHandler
    : IRequestHandler<GetAllSubjunctionsQuery, ErrorOr<List<SubjunctionResult>>>
{
    private readonly ISubjunctionRepository subjunctionRepository;

    public GetAllSubjunctionsQueryHandler(ISubjunctionRepository subjunctionRepository)
    {
        this.subjunctionRepository = subjunctionRepository;
    }

    public async Task<ErrorOr<List<SubjunctionResult>>> Handle(
        GetAllSubjunctionsQuery query,
        CancellationToken cancellationToken
    )
    {
        var subjunctions = await this.subjunctionRepository.GetAll(cancellationToken);

        var subjunctionResults = subjunctions
            .Select(subjunction => new SubjunctionResult(
                subjunction.Id.Value,
                subjunction.Time,
                subjunction.Arsak,
                subjunction.Hensikt,
                subjunction.Betingelse,
                subjunction.Motsetning,
                subjunction.CreatedDateTime,
                subjunction.UpdatedDateTime
            ))
            .ToList();

        return subjunctionResults;
    }
}
