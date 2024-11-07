using NorskApi.Contracts.Essay.Common.Enums;

namespace NorskApi.Contracts.Essay.Requests;

public record CreateParagraphRequest(string? Title, string Content, ContentType ContentType);
