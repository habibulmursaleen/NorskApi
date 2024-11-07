using NorskApi.Contracts.Essay.Common.Enums;

namespace NorskApi.Contracts.Essay.Requests;

public record UpdateParagraphRequest(
    Guid Id,
    string? Title,
    string Content,
    ContentType ContentType
);
