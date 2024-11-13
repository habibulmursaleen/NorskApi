using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.GrammarRules.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.Entites;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;
using Exception = NorskApi.Domain.GrammmarRuleAggregate.Entites.Exception;

namespace NorskApi.Application.GrammarRules.Queries.GetGrammarRuleById;

public record GetGrammarRuleByIdQueryHandler
    : IRequestHandler<GetGrammarRuleByIdQuery, ErrorOr<GrammarRuleResult>>
{
    private readonly IGrammarRuleRepository grammarRuleRepository;

    public GetGrammarRuleByIdQueryHandler(IGrammarRuleRepository grammarRuleRepository)
    {
        this.grammarRuleRepository = grammarRuleRepository;
    }

    public async Task<ErrorOr<GrammarRuleResult>> Handle(
        GetGrammarRuleByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a GrammarRuleId from the Guid
        GrammarRuleId grammarRuleId = GrammarRuleId.Create(query.Id);
        TopicId topicId = TopicId.Create(query.TopicId);

        GrammarRule? grammarRule = await grammarRuleRepository.GetById(
            topicId,
            grammarRuleId,
            cancellationToken
        );

        if (grammarRule is null)
        {
            return Errors.GrammarRulesErrors.GrammarRulesNotFound(query.Id);
        }

        List<ExceptionResult> exceptions = new List<ExceptionResult>();
        List<ExampleOfRuleResult> exampleOfRules = new List<ExampleOfRuleResult>();

        foreach (Exception exception in grammarRule.Exceptions)
        {
            exceptions.Add(
                new ExceptionResult(
                    exception.Id.Value,
                    exception.GrammarRuleId_FK.Value,
                    exception.Title,
                    exception.Description,
                    exception.Comments,
                    exception.CorrectSentence,
                    exception.IncorrectSentence,
                    exception.CreatedDateTime,
                    exception.UpdatedDateTime
                )
            );
        }

        foreach (ExampleOfRule exampleOfRule in grammarRule.ExampleOfRules)
        {
            exampleOfRules.Add(
                new ExampleOfRuleResult(
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
                )
            );
        }

        return new GrammarRuleResult(
            grammarRule.Id.Value,
            grammarRule.TopicId.Value,
            grammarRule.Label,
            grammarRule.Description,
            grammarRule.ExplanatoryNotes,
            grammarRule
                .SentenceStructures.Select(sentenceStructure => new SentenceStructureResult(
                    sentenceStructure.Label
                ))
                .ToList(),
            grammarRule.RuleType,
            grammarRule.DifficultyLevel,
            grammarRule
                .GrammarRuleTagIds.Select(tagId => new GrammarRuleTagIdResult(tagId.Value))
                .ToList(),
            grammarRule.AdditionalInformation,
            grammarRule.Comments,
            grammarRule
                .RelatedGrammarRuleIds?.Select(x => new RelatedRuleIdResult(x.Value))
                .ToList() ?? new List<RelatedRuleIdResult>(),
            exceptions,
            exampleOfRules,
            grammarRule.CreatedDateTime,
            grammarRule.UpdatedDateTime
        );
    }
}
