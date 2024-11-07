using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Essay.Requests;

public record UpdateEssayRequest(
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
    List<UpdateParagraphRequest> Paragraphs
);
