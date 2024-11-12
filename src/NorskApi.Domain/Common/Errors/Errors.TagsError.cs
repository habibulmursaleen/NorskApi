namespace NorskApi.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class TagErrors
    {
        public static Error TagNotFound(Guid TagId) =>
            Error.NotFound(code: "404", description: $"Tag with id {TagId} not found.");
    }
}
