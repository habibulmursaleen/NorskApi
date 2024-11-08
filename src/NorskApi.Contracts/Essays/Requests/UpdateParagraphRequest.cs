using NorskApi.Contracts.Essays.Common.Enums;

namespace NorskApi.Contracts.Essays.Requests;

public record UpdateParagraphRequest(
    Guid Id,
    string? Title,
    string Content,
    ContentType ContentType
);
