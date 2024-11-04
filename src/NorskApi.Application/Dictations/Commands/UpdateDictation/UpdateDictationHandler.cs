using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Dictations.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.DictationAggregate;
using NorskApi.Domain.DictationAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Application.Dictations.Commands.UpdateDictation;

public class UpdateDictationHandler
    : IRequestHandler<UpdateDictationCommand, ErrorOr<DictationResult>>
{
    private readonly IDictationRepository dictationRepository;

    public UpdateDictationHandler(IDictationRepository dictationRepository)
    {
        this.dictationRepository = dictationRepository;
    }

    public async Task<ErrorOr<DictationResult>> Handle(
        UpdateDictationCommand command,
        CancellationToken cancellationToken
    )
    {
        var dictationId = DictationId.Create(command.Id);
        var essayId = command.EssayId is not null ? EssayId.Create(command.EssayId.Value) : null;
        Dictation? dictation = await dictationRepository.GetById(dictationId, cancellationToken);

        if (dictation is null)
        {
            return Errors.DictationErrors.DictationNotFound(command.Id);
        }

        dictation.Update(
            essayId,
            command.Label,
            command.Content,
            command.Answer,
            command.IsCompleted,
            command.DifficultyLevel
        );

        await this.dictationRepository.Update(dictation, cancellationToken);

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
