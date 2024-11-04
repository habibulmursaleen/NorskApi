using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Dictations.Models;
using NorskApi.Domain.DictationAggregate;

namespace NorskApi.Application.Dictations.Queries.GetAllDictations;

public class GetAllDictationsQueryHandler
    : IRequestHandler<GetAllDictationsQuery, ErrorOr<List<DictationResult>>>
{
    private readonly IDictationRepository dictationRepository;

    public GetAllDictationsQueryHandler(IDictationRepository dictationRepository)
    {
        this.dictationRepository = dictationRepository;
    }

    public async Task<ErrorOr<List<DictationResult>>> Handle(
        GetAllDictationsQuery query,
        CancellationToken cancellationToken
    )
    {
        List<Dictation> dictations = new List<Dictation>();
        QueryParamsWithEssayFilters? filters = query.Filters;
        var dictation = await this.dictationRepository.GetAll(filters, cancellationToken);

        var dictationResults = dictation
            .Select(dictation => new DictationResult(
                dictation.Id.Value,
                dictation.EssayId?.Value,
                dictation.Label,
                dictation.Content,
                dictation.Answer,
                dictation.IsCompleted,
                dictation.DifficultyLevel,
                dictation.CreatedDateTime,
                dictation.UpdatedDateTime
            ))
            .ToList();

        return dictationResults;
    }
}
