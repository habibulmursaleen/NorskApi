using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.GrammarRules.Models;
using NorskApi.Application.Words.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.WordAggregate;
using NorskApi.Domain.WordAggregate.ValueObjects;

namespace NorskApi.Application.Words.Queries.GetWordById;

public record GetWordByIdQueryHandler : IRequestHandler<GetWordByIdQuery, ErrorOr<WordResult>>
{
    private readonly IWordRepository wordRepository;

    public GetWordByIdQueryHandler(IWordRepository wordRepository)
    {
        this.wordRepository = wordRepository;
    }

    public async Task<ErrorOr<WordResult>> Handle(
        GetWordByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a WordId from the Guid
        WordId wordId = WordId.Create(query.Id);

        Word? word = await wordRepository.GetById(wordId, cancellationToken);

        if (word is null)
        {
            return Errors.WordsErrors.WordsNotFound(query.Id);
        }

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
            word.SynonymIds?.Select(x => x.Value).ToList() ?? new List<Guid>(),
            word.AntonymIds?.Select(x => x.Value).ToList() ?? new List<Guid>(),
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
