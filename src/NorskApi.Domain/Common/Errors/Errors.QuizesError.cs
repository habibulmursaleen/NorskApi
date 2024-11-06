using ErrorOr;

namespace NorskApi.Domain.Common.Errors;

public static partial class Errors
{
    public static class QuizesErrors
    {
        public static Error QuizesNotFound(Guid id) =>
            Error.NotFound(code: "404", description: $"Quizes with id {id} not found.");

        public static Error QuizesError(string description) =>
            Error.Conflict(code: "404", description: description);
    }
}
