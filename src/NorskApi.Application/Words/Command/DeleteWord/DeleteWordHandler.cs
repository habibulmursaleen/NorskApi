namespace NorskApi.Application.Words.Command.DeleteWord;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;
using NorskApi.Domain.WordAggregate;
using NorskApi.Domain.WordAggregate.ValueObjects;

public class DeleteWordHandler : IRequestHandler<DeleteWordCommand, ErrorOr<DeleteWordResult>>
{
    private readonly IWordRepository wordRepository;

    public DeleteWordHandler(IWordRepository wordRepository)
    {
        this.wordRepository = wordRepository;
    }

    public async Task<ErrorOr<DeleteWordResult>> Handle(
        DeleteWordCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a WordId from the Guid
        WordId wordId = WordId.Create(command.Id);

        Word? word = await wordRepository.GetById(wordId, cancellationToken);

        if (word is null)
        {
            return Errors.WordsErrors.WordsNotFound(command.Id);
        }

        word.Delete();

        await wordRepository.Delete(word, cancellationToken);

        return new DeleteWordResult(word.Id.Value);
    }
}
