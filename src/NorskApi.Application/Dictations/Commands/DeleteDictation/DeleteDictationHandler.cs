namespace NorskApi.Application.Dictations.Commands.DeleteDictation;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.DictationAggregate;
using NorskApi.Domain.DictationAggregate.ValueObjects;

public class DeleteDictationHandler
    : IRequestHandler<DeleteDictationCommand, ErrorOr<DeleteDictationResult>>
{
    private readonly IDictationRepository dictationRepository;

    public DeleteDictationHandler(IDictationRepository dictationRepository)
    {
        this.dictationRepository = dictationRepository;
    }

    public async Task<ErrorOr<DeleteDictationResult>> Handle(
        DeleteDictationCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a DictationId from the Guid
        DictationId dictationId = DictationId.Create(command.Id);

        Dictation? dictation = await dictationRepository.GetById(dictationId, cancellationToken);

        if (dictation is null)
        {
            return Errors.DictationErrors.DictationNotFound(command.Id);
        }

        await dictationRepository.Delete(dictation, cancellationToken);

        return new DeleteDictationResult(dictation.Id.Value);
    }
}
