using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Dictations.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.DictationAggregate;
using NorskApi.Domain.DictationAggregate.ValueObjects;

namespace NorskApi.Application.Dictations.Queries.GetDictationById;

public record GetDictationByIdQueryHandler
    : IRequestHandler<GetDictationByIdQuery, ErrorOr<DictationResult>>
{
    private readonly IDictationRepository dictationRepository;

    public GetDictationByIdQueryHandler(IDictationRepository dictationRepository)
    {
        this.dictationRepository = dictationRepository;
    }

    public async Task<ErrorOr<DictationResult>> Handle(
        GetDictationByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a DictationId from the Guid
        DictationId dictationId = DictationId.Create(query.Id);
        Dictation? dictation = await dictationRepository.GetById(dictationId, cancellationToken);

        if (dictation is null)
        {
            return Errors.DictationErrors.DictationNotFound(query.Id);
        }

        return new DictationResult(
            dictation.Id.Value,
            dictation.EssayId?.Value,
            dictation.Label,
            dictation.Content,
            dictation.Answer,
            dictation.IsCompleted,
            dictation.DifficultyLevel,
            dictation.CreatedDateTime,
            dictation.UpdatedDateTime
        );
    }
}
