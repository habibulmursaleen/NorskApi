using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Essays.Common.Enums;

namespace NorskApi.Contracts.Essays.Response;

public record EssayResponse(
    Guid Id,
    string Logo,
    string Label,
    string Description,
    double Progress,
    List<string> Activities,
    Status Status,
    string Notes,
    bool IsCompleted,
    bool IsSaved,
    List<string> Tags,
    DifficultyLevel DifficultyLevel,
    List<ParagraphResponse> Paragraphs,
    List<Guid> RelatedGrammarTopicIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record ParagraphResponse(
    Guid Id,
    string Title,
    string Content,
    ContentType ContentType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record EssayLiteResponse(
    Guid Id,
    string Logo,
    string Label,
    string Description,
    double Progress,
    List<string> Activities,
    Status Status,
    bool IsCompleted,
    bool IsSaved,
    List<string> Tags,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
