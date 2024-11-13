namespace NorskApi.Application.Essays.Models;

public record RoleplayResult(
    Guid Id,
    string Content,
    bool IsCompleted,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
