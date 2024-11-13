using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.GrammarRules.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.Entites;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;
using NorskApi.Domain.TagAggregate.ValueObjects;
using Exception = NorskApi.Domain.GrammmarRuleAggregate.Entites.Exception;

namespace NorskApi.Application.GrammarRules.Command.UpdateGrammarRule;

public class UpdateGrammarRuleHandler
    : IRequestHandler<UpdateGrammarRuleCommand, ErrorOr<GrammarRuleResult>>
{
    private readonly IGrammarRuleRepository grammarRuleRepository;

    public UpdateGrammarRuleHandler(IGrammarRuleRepository grammarRuleRepository)
    {
        this.grammarRuleRepository = grammarRuleRepository;
    }

    public async Task<ErrorOr<GrammarRuleResult>> Handle(
        UpdateGrammarRuleCommand command,
        CancellationToken cancellationToken
    )
    {
        GrammarRuleId grammarRuleId = GrammarRuleId.Create(command.Id);
        TopicId topicId = TopicId.Create(command.TopicId);

        GrammarRule? grammarRule = await grammarRuleRepository.GetById(
            topicId,
            grammarRuleId,
            cancellationToken
        );

        if (grammarRule is null)
        {
            return Errors.GrammarRulesErrors.GrammarRulesNotFound(command.Id);
        }

        List<Exception> exceptionsToUpdate = [];
        List<ExampleOfRule> exampleOfRulesToUpdate = [];
        List<SentenceStructure> SentenceStructureToUpdate = [];

        if (command.Exceptions != null)
        {
            foreach (UpdateExceptionCommand updateException in command.Exceptions)
            {
                ExceptionId exceptionId = ExceptionId.Create(updateException.Id);
                Exception? exception = grammarRule.Exceptions.FirstOrDefault(exception =>
                    exception.Id == exceptionId
                );

                if (exception is null)
                {
                    exceptionsToUpdate.Add(
                        Exception.Create(
                            grammarRuleId,
                            updateException.Title,
                            updateException.Description,
                            updateException.Comments,
                            updateException.CorrectSentence,
                            updateException.IncorrectSentence
                        )
                    );
                }
                else
                {
                    exception.Update(
                        grammarRuleId,
                        updateException.Title,
                        updateException.Description,
                        updateException.Comments,
                        updateException.CorrectSentence,
                        updateException.IncorrectSentence
                    );
                    exceptionsToUpdate.Add(exception);
                }
            }
        }

        var exceptionsToRemove = grammarRule
            .Exceptions.Where(exception =>
                command.Exceptions != null
                && !command.Exceptions.Any(updateException =>
                    updateException.Id == exception.Id.Value
                )
            )
            .ToList();

        exceptionsToUpdate = exceptionsToUpdate
            .Where(exception => !exceptionsToRemove.Contains(exception))
            .ToList();

        if (command.SentenceStructures != null)
        {
            foreach (
                UpdateSentenceStructureCommand updateSentenceStructure in command.SentenceStructures
            )
            {
                SentenceStructureId sentenceStructureId = SentenceStructureId.Create(
                    updateSentenceStructure.Id
                );
                SentenceStructure? sentenceStructure =
                    grammarRule.SentenceStructures.FirstOrDefault(sentenceStructure =>
                        sentenceStructure.Id == sentenceStructureId
                    );

                if (sentenceStructure is null)
                {
                    SentenceStructureToUpdate.Add(
                        SentenceStructure.Create(updateSentenceStructure.Label)
                    );
                }
                else
                {
                    sentenceStructure.Update(updateSentenceStructure.Label);
                    SentenceStructureToUpdate.Add(sentenceStructure);
                }
            }
        }

        if (command.ExampleOfRules != null)
        {
            foreach (UpdateExampleOfRuleCommand updateExampleOfRule in command.ExampleOfRules)
            {
                ExampleOfRuleId exampleOfRuleId = ExampleOfRuleId.Create(updateExampleOfRule.Id);
                ExampleOfRule? exampleOfRule = grammarRule.ExampleOfRules.FirstOrDefault(
                    exampleOfRule => exampleOfRule.Id == exampleOfRuleId
                );

                if (exampleOfRule is null)
                {
                    exampleOfRulesToUpdate.Add(
                        ExampleOfRule.Create(
                            grammarRuleId,
                            updateExampleOfRule.Subjunction,
                            updateExampleOfRule.Subject,
                            updateExampleOfRule.Adverbial,
                            updateExampleOfRule.Verb,
                            updateExampleOfRule.Object,
                            updateExampleOfRule.Rest,
                            updateExampleOfRule.CorrectSentence,
                            updateExampleOfRule.EnglishSentence,
                            updateExampleOfRule.IncorrectSentence,
                            updateExampleOfRule.TransformationFrom,
                            updateExampleOfRule.TransformationTo
                        )
                    );
                }
                else
                {
                    exampleOfRule.Update(
                        grammarRuleId,
                        updateExampleOfRule.Subjunction,
                        updateExampleOfRule.Subject,
                        updateExampleOfRule.Adverbial,
                        updateExampleOfRule.Verb,
                        updateExampleOfRule.Object,
                        updateExampleOfRule.Rest,
                        updateExampleOfRule.CorrectSentence,
                        updateExampleOfRule.EnglishSentence,
                        updateExampleOfRule.IncorrectSentence,
                        updateExampleOfRule.TransformationFrom,
                        updateExampleOfRule.TransformationTo
                    );
                    exampleOfRulesToUpdate.Add(exampleOfRule);
                }
            }
        }

        var exampleOfRulesToRemove = grammarRule
            .ExampleOfRules.Where(exampleOfRule =>
                command.ExampleOfRules != null
                && !command.ExampleOfRules.Any(updateExampleOfRule =>
                    updateExampleOfRule.Id == exampleOfRule.Id.Value
                )
            )
            .ToList();

        exampleOfRulesToUpdate = exampleOfRulesToUpdate
            .Where(exampleOfRule => !exampleOfRulesToRemove.Contains(exampleOfRule))
            .ToList();

        grammarRule.Update(
            topicId,
            command.Label,
            command.Description,
            command.ExplanatoryNotes,
            SentenceStructureToUpdate,
            command.RuleType,
            command.DifficultyLevel,
            command.GrammarRuleTagIds?.Select(x => TagId.Create(x.TagId)).ToList()
                ?? new List<TagId>(),
            command.AdditionalInformation,
            command.Comments ?? new List<string>(),
            command
                .RelatedGrammarRuleIds?.Select(x => GrammarRuleId.Create(x.GrammarRuleId))
                .ToList() ?? new List<GrammarRuleId>(),
            exceptionsToUpdate,
            exampleOfRulesToUpdate
        );

        await this.grammarRuleRepository.Update(grammarRule, cancellationToken);

        List<ExceptionResult> exceptionsResult = exceptionsToUpdate
            .Select(exception => new ExceptionResult(
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
            .ToList();

        List<ExampleOfRuleResult> exampleOfRulesResult = exampleOfRulesToUpdate
            .Select(exampleOfRule => new ExampleOfRuleResult(
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
            .ToList();

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
            exceptionsResult,
            exampleOfRulesResult,
            grammarRule.CreatedDateTime,
            grammarRule.UpdatedDateTime
        );
    }
}
