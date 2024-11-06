using ErrorOr;
using MediatR;
using NorskApi.Application.GrammarTopics.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.GrammarTopics.Commands.CreateGrammarTopic;

public record CreateGrammarTopicCommand(
    string Label,
    string Description,
    Status Status,
    double Chapter,
    double ModuleCount,
    double Progress,
    bool IsCompleted,
    bool IsSaved,
    List<string> Tags,
    DifficultyLevel DifficultyLevel
) : IRequest<ErrorOr<GrammarTopicResult>>;
