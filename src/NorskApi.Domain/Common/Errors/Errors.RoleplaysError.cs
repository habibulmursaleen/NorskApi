namespace NorskApi.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class RoleplayErrors
    {
        public static Error RoleplayNotFound(Guid RoleplayId, Guid EssayId) =>
            Error.NotFound(
                code: "404",
                description: $"Roleplay with id {RoleplayId} or essayId {EssayId} not found."
            );
    }
}
