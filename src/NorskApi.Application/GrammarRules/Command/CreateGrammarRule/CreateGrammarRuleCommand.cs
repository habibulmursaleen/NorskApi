using ErrorOr;
using MediatR;
using NorskApi.Application.GrammarRules.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.GrammarRules.Command.CreateGrammarRule;

public record CreateGrammarRuleCommand(
    Guid TopicId,
    string Label,
    string? Description,
    string? ExplanatoryNotes,
    List<CreateSentenceStructureCommand> SentenceStructures,
    string? RuleType,
    DifficultyLevel DifficultyLevel,
    List<CreateGrammarRuleTagIdCommand>? GrammarRuleTagIds,
    string? AdditionalInformation,
    List<string>? Comments,
    List<CreateRelatedRuleIdCommand>? RelatedGrammarRuleIds,
    List<CreateExceptionCommand>? Exceptions,
    List<CreateExampleOfRuleCommand>? ExampleOfRules
) : IRequest<ErrorOr<GrammarRuleResult>>;

public record CreateExceptionCommand(
    string? Title,
    string? Description,
    string? Comments,
    string? CorrectSentence,
    string? IncorrectSentence
);

public record CreateExampleOfRuleCommand(
    string? Subjunction,
    string? Subject,
    string? Adverbial,
    string? Verb,
    string? Object,
    string? Rest,
    string? CorrectSentence,
    string? EnglishSentence,
    string? IncorrectSentence,
    string? TransformationFrom,
    string? TransformationTo
);

public record CreateSentenceStructureCommand(string Label);

public record CreateRelatedRuleIdCommand(Guid GrammarRuleId);

public record CreateGrammarRuleTagIdCommand(Guid TagId);
