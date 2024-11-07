using NorskApi.Domain.EssayAggregate.Enums;

namespace NorskApi.Application.Essays.Models;

public record ParagraphResult(
    Guid Id,
    string? Title,
    string Content,
    ContentType ContentType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
