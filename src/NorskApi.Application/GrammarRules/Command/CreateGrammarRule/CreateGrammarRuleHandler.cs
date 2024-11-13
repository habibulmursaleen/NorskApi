using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.GrammarRules.Models;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.Entites;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;
using NorskApi.Domain.TagAggregate.ValueObjects;
using Exception = NorskApi.Domain.GrammmarRuleAggregate.Entites.Exception;

namespace NorskApi.Application.GrammarRules.Command.CreateGrammarRule;

public class CreateGrammarRuleHandler
    : IRequestHandler<CreateGrammarRuleCommand, ErrorOr<GrammarRuleResult>>
{
    private readonly IGrammarRuleRepository grammarRuleRepository;

    public CreateGrammarRuleHandler(IGrammarRuleRepository grammarRuleRepository)
    {
        this.grammarRuleRepository = grammarRuleRepository;
    }

    public async Task<ErrorOr<GrammarRuleResult>> Handle(
        CreateGrammarRuleCommand command,
        CancellationToken cancellationToken
    )
    {
        GrammarRule grammarRule = GrammarRule.Create(
            TopicId.Create(command.TopicId),
            command.Label,
            command.Description,
            command.ExplanatoryNotes,
            command
                .SentenceStructures.Select(sentenceStructure =>
                    SentenceStructure.Create(sentenceStructure.Label)
                )
                .ToList(),
            command.RuleType,
            command.DifficultyLevel,
            command.GrammarRuleTagIds?.Select(x => TagId.Create(x.TagId)).ToList()
                ?? new List<TagId>(),
            command.AdditionalInformation,
            command.Comments ?? new List<string>(),
            command
                .RelatedGrammarRuleIds?.Select(x => GrammarRuleId.Create(x.GrammarRuleId))
                .ToList() ?? new List<GrammarRuleId>(),
            [],
            []
        );

        var exceptions = command
            .Exceptions?.Select(exception =>
                Exception.Create(
                    GrammarRuleId.Create(grammarRule.Id.Value), // Use the newly assigned Id
                    exception.Title,
                    exception.Description,
                    exception.Comments,
                    exception.CorrectSentence,
                    exception.IncorrectSentence
                )
            )
            .ToList();

        var exampleOfRules = command
            .ExampleOfRules?.Select(exampleOfRule =>
                ExampleOfRule.Create(
                    GrammarRuleId.Create(grammarRule.Id.Value), // Use the newly assigned Id
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
                    exampleOfRule.TransformationTo
                )
            )
            .ToList();

        if (exceptions != null)
        {
            grammarRule.AddExceptions(exceptions);
        }
        if (exampleOfRules != null)
        {
            grammarRule.AddExampleOfRules(exampleOfRules);
        }

        await this.grammarRuleRepository.Add(grammarRule, cancellationToken);

        var result = new GrammarRuleResult(
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
        );

        return result;
    }
}
