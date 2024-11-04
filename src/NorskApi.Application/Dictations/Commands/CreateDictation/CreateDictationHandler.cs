namespace NorskApi.Application.Dictations.Commands.CreateDictation;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Dictations.Models;
using NorskApi.Domain.DictationAggregate;
using NorskApi.Domain.EssayAggregate.ValueObjects;

public class CreateDictationHandler
    : IRequestHandler<CreateDictationCommand, ErrorOr<DictationResult>>
{
    private readonly IDictationRepository dictationRepository;

    public CreateDictationHandler(IDictationRepository dictationRepository)
    {
        this.dictationRepository = dictationRepository;
    }

    public async Task<ErrorOr<DictationResult>> Handle(
        CreateDictationCommand command,
        CancellationToken cancellationToken
    )
    {
        Dictation dictation = Dictation.Create(
            command.EssayId is not null ? EssayId.Create(command.EssayId.Value) : null,
            command.Label,
            command.Content,
            command.Answer,
            command.IsCompleted,
            command.DifficultyLevel
        );

        await this.dictationRepository.Add(dictation, cancellationToken);

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
