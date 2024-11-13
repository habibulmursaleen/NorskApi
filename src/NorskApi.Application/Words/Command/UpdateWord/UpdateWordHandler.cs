using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.GrammarRules.Models;
using NorskApi.Application.Words.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.WordAggregate;
using NorskApi.Domain.WordAggregate.Entites;
using NorskApi.Domain.WordAggregate.ValueObjects;

namespace NorskApi.Application.Words.Command.UpdateWord;

public class UpdateWordHandler : IRequestHandler<UpdateWordCommand, ErrorOr<WordResult>>
{
    private readonly IWordRepository wordRepository;

    public UpdateWordHandler(IWordRepository wordRepository)
    {
        this.wordRepository = wordRepository;
    }

    public async Task<ErrorOr<WordResult>> Handle(
        UpdateWordCommand command,
        CancellationToken cancellationToken
    )
    {
        WordId wordId = WordId.Create(command.Id);

        Word? word = await wordRepository.GetById(wordId, cancellationToken);
        EssayId? essayId = command.EssayId != null ? EssayId.Create(command.EssayId.Value) : null;

        if (word is null)
        {
            return Errors.WordsErrors.WordsNotFound(command.Id);
        }

        WordGrammer? wordGrammer = null;
        if (command.WordGrammer != null)
        {
            wordGrammer = WordGrammer.Create(
                WordId.Create(word.Id.Value), // Use the newly assigned Id
                command.WordGrammer.GenderMasculine,
                command.WordGrammer.GenderFeminine,
                command.WordGrammer.GenderNeutral,
                command.WordGrammer.SingularDefinitiv,
                command.WordGrammer.SingularIndefinitiv,
                command.WordGrammer.PluralDefinitiv,
                command.WordGrammer.PluralIndefinitiv,
                command.WordGrammer.Infinitiv,
                command.WordGrammer.PresentTense,
                command.WordGrammer.PastTense,
                command.WordGrammer.PresentPerfectTense,
                command.WordGrammer.FutureTense,
                command.WordGrammer.Positive,
                command.WordGrammer.Comparative,
                command.WordGrammer.Superlative,
                command.WordGrammer.SuperlativeDetermined,
                command.WordGrammer.PastParticiple,
                command.WordGrammer.PresentParticiple,
                command.WordGrammer.Irregular,
                command.WordGrammer.StrongVerb,
                command.WordGrammer.WeakVerb
            );
            word.AddWordGrammer(wordGrammer);
        }

        WordUsageExample? wordUsageExample = null;
        if (command.WordUsageExample != null)
        {
            wordUsageExample = WordUsageExample.Create(
                WordId.Create(word.Id.Value), // Use the newly assigned Id
                command.WordUsageExample.CorrectSentence,
                command.WordUsageExample.IncorrectSentence,
                command.WordUsageExample.EnglishSentence,
                command.WordUsageExample.NewSentence
            );
            word.AddWordUsageExample(wordUsageExample);
        }

        word.Update(
            essayId,
            command.Title,
            command.Meaning,
            command.EnTranslation,
            command.NativeMeaning,
            command.Type,
            command.PartOfSpeechTag,
            command.DifficultyLevel,
            command.IsCompleted,
            command.WordSynonymIds?.Select(x => WordId.Create(x.WordId)).ToList()
                ?? new List<WordId>(),
            command.WordAntonymIds?.Select(x => WordId.Create(x.WordId)).ToList()
                ?? new List<WordId>(),
            wordGrammer,
            wordUsageExample
        );

        await this.wordRepository.Update(word, cancellationToken);

        var result = new WordResult(
            word.Id.Value,
            word.EssayId?.Value,
            word.Title,
            word.Meaning,
            word.EnTranslation,
            word.NativeMeaning,
            word.Type,
            word.PartOfSpeechTag,
            word.DifficultyLevel,
            word.IsCompleted,
            word.SynonymIds?.Select(x => new WordSynonymeIdsResult(x.Value)).ToList()
                ?? new List<WordSynonymeIdsResult>(),
            word.AntonymIds?.Select(x => new WordAntonymeIdsResult(x.Value)).ToList()
                ?? new List<WordAntonymeIdsResult>(),
            new WordGrammerResult(
                word.WordGrammer?.Id.Value ?? Guid.Empty,
                word.WordGrammer?.WordId_FK?.Value,
                word.WordGrammer?.GenderMasculine,
                word.WordGrammer?.GenderFeminine,
                word.WordGrammer?.GenderNeutral,
                word.WordGrammer?.SingularDefinitiv,
                word.WordGrammer?.SingularIndefinitiv,
                word.WordGrammer?.PluralDefinitiv,
                word.WordGrammer?.PluralIndefinitiv,
                word.WordGrammer?.Infinitiv,
                word.WordGrammer?.PresentTense,
                word.WordGrammer?.PastTense,
                word.WordGrammer?.PresentPerfectTense,
                word.WordGrammer?.FutureTense,
                word.WordGrammer?.Positive,
                word.WordGrammer?.Comparative,
                word.WordGrammer?.Superlative,
                word.WordGrammer?.SuperlativeDetermined,
                word.WordGrammer?.PastParticiple,
                word.WordGrammer?.PresentParticiple,
                word.WordGrammer?.Irregular,
                word.WordGrammer?.StrongVerb,
                word.WordGrammer?.WeakVerb,
                word.WordGrammer?.CreatedDateTime ?? DateTime.MinValue,
                word.WordGrammer?.UpdatedDateTime ?? DateTime.MinValue
            ),
            new WordUsageExampleResult(
                word.WordUsageExample?.Id.Value ?? Guid.Empty,
                word.WordUsageExample?.WordId_FK?.Value,
                word.WordUsageExample?.CorrectSentence,
                word.WordUsageExample?.IncorrectSentence,
                word.WordUsageExample?.EnglishSentence,
                word.WordUsageExample?.NewSentence,
                word.WordUsageExample?.CreatedDateTime ?? DateTime.MinValue,
                word.WordUsageExample?.UpdatedDateTime ?? DateTime.MinValue
            ),
            word.CreatedDateTime,
            word.UpdatedDateTime
        );

        return result;
    }
}
