using ErrorOr;

namespace NorskApi.Domain.Common.Errors;

public static partial class Errors
{
    public static class WordsErrors
    {
        public static Error WordsNotFound(Guid id) =>
            Error.NotFound(code: "404", description: $"WordsErrors with id {id} not found.");

        public static Error WordsError(string description) =>
            Error.Conflict(code: "404", description: description);
    }
}
