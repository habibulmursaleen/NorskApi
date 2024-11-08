using ErrorOr;
using MediatR;
using NorskApi.Application.GrammarRules.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.GrammarRules.Command.UpdateGrammarRule;

public record UpdateGrammarRuleCommand(
    Guid Id,
    Guid TopicId,
    string Label,
    string? Description,
    string? ExplanatoryNotes,
    List<string>? SentenceStructure,
    string? RuleType,
    DifficultyLevel DifficultyLevel,
    List<string>? Tags,
    string? AdditionalInformation,
    List<string>? Comments,
    List<Guid>? RelatedRuleIds,
    List<UpdateExceptionCommand>? Exceptions,
    List<UpdateExampleOfRuleCommand>? ExampleOfRules
) : IRequest<ErrorOr<GrammarRuleResult>>;

public record UpdateExceptionCommand(
    Guid Id,
    Guid GrammarRuleId,
    string? Title,
    string? Description,
    string? Comments,
    string? CorrectSentence,
    string? IncorrectSentence
);

public record UpdateExampleOfRuleCommand(
    Guid Id,
    Guid GrammarRuleId,
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
