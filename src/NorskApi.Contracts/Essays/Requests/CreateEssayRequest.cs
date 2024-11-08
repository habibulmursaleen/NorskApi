using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Quizes.Common.Enums;

namespace NorskApi.Contracts.Essays.Requests;

public record CreateEssayRequest(
    string? Logo,
    string Label,
    string? Description,
    double Progress,
    List<string>? Activities,
    Status Status,
    string Notes,
    bool IsCompleted,
    bool IsSaved,
    List<string>? Tags,
    DifficultyLevel DifficultyLevel,
    List<Guid>? RelatedGrammarTopicIds,
    List<CreateParagraphRequest> Paragraphs
);
