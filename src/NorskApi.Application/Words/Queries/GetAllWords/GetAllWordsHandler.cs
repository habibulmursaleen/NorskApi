using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.GrammarRules.Models;
using NorskApi.Application.Words.Models;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;
using NorskApi.Domain.WordAggregate;

namespace NorskApi.Application.Words.Queries.GetAllWords;

public class GetAllWordsQueryHandler : IRequestHandler<GetAllWordsQuery, ErrorOr<List<WordResult>>>
{
    private readonly IWordRepository wordRepository;

    public GetAllWordsQueryHandler(IWordRepository wordRepository)
    {
        this.wordRepository = wordRepository;
    }

    public async Task<ErrorOr<List<WordResult>>> Handle(
        GetAllWordsQuery query,
        CancellationToken cancellationToken
    )
    {
        List<Word> words = [];
        QueryParamsWithEssayFilters? filters = query.Filters;
        words = await this.wordRepository.GetAll(filters, cancellationToken);

        List<WordResult> wordResult = words
            .Select(word => new WordResult(
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
            ))
            .ToList();

        return wordResult;
    }
}
