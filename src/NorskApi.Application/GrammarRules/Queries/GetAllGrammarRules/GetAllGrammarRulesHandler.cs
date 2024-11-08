using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.GrammarRules.Models;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

namespace NorskApi.Application.GrammarRules.Queries.GetAllGrammarRules;

public class GetAllGrammarRulesQueryHandler
    : IRequestHandler<GetAllGrammarRulesQuery, ErrorOr<List<GrammarRuleResult>>>
{
    private readonly IGrammarRuleRepository grammarRuleRepository;

    public GetAllGrammarRulesQueryHandler(IGrammarRuleRepository grammarRuleRepository)
    {
        this.grammarRuleRepository = grammarRuleRepository;
    }

    public async Task<ErrorOr<List<GrammarRuleResult>>> Handle(
        GetAllGrammarRulesQuery query,
        CancellationToken cancellationToken
    )
    {
        List<GrammarRule> grammarRules = [];
        QueryParamsWithTopicFilters? filters = query.Filters;
        if (query.TopicId == Guid.Empty)
        {
            grammarRules = await this.grammarRuleRepository.GetAll(filters, cancellationToken);
        }
        else
        {
            var topicId = TopicId.Create(query.TopicId ?? Guid.Empty);
            grammarRules = await this.grammarRuleRepository.GetAllByTopicId(
                topicId,
                filters,
                cancellationToken
            );
        }

        var grammarRuleResult = grammarRules
            .Select(grammarRule => new GrammarRuleResult(
                grammarRule.Id.Value,
                grammarRule.TopicId.Value,
                grammarRule.Label,
                grammarRule.Description,
                grammarRule.ExplanatoryNotes,
                grammarRule.SentenceStructure,
                grammarRule.RuleType,
                grammarRule.DifficultyLevel,
                grammarRule.Tags,
                grammarRule.AdditionalInformation,
                grammarRule.Comments,
                grammarRule.RelatedRuleIds?.Select(id => GrammarRuleId.Create(id)).ToList(),
                grammarRule
                    .Exceptions.Select(exception => new ExceptionResult(
                        exception.Id.Value,
                        exception.GrammarRuleId_FK.Value,
                        exception.Title,
                        exception.Description,
                        exception.Comments,
                        exception.CorrectSentence,
                        exception.IncorrectSentence,
                        exception.CreatedDateTime,
                        exception.UpdatedDateTime
                    ))
                    .ToList(),
                grammarRule
                    .ExampleOfRules.Select(exampleOfRule => new ExampleOfRuleResult(
                        exampleOfRule.Id.Value,
                        exampleOfRule.GrammarRuleId_FK.Value,
                        exampleOfRule.Subjunction,
                        exampleOfRule.Subject,
                        exampleOfRule.Adverbial,
                        exampleOfRule.Verb,
                        exampleOfRule.Object,
                        exampleOfRule.Rest,
                        exampleOfRule.CorrectSentence,
                        exampleOfRule.EnglishSentence,
                        exampleOfRule.IncorrectSentence,
                        exampleOfRule.TransformationFrom,
                        exampleOfRule.TransformationTo,
                        exampleOfRule.CreatedDateTime,
                        exampleOfRule.UpdatedDateTime
                    ))
                    .ToList(),
                grammarRule.CreatedDateTime,
                grammarRule.UpdatedDateTime
            ))
            .ToList();

        return grammarRuleResult;
    }
}
