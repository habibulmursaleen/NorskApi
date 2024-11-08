using NorskApi.Contracts.Essays.Common.Enums;

namespace NorskApi.Contracts.Essays.Requests;

public record CreateParagraphRequest(string? Title, string Content, ContentType ContentType);
