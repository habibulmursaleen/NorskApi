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
    List<string>? SentenceStructure,
    string? RuleType,
    DifficultyLevel DifficultyLevel,
    List<string>? Tags,
    string? AdditionalInformation,
    List<string>? Comments,
    List<Guid>? RelatedRuleIds,
    List<CreateExceptionCommand>? Exceptions,
    List<CreateExampleOfRuleCommand>? ExampleOfRules
) : IRequest<ErrorOr<GrammarRuleResult>>;

public record CreateExceptionCommand(
    Guid GrammarRuleId,
    string? Title,
    string? Description,
    string? Comments,
    string? CorrectSentence,
    string? IncorrectSentence
);

public record CreateExampleOfRuleCommand(
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
