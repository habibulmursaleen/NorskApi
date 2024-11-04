namespace NorskApi.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class DictationErrors
    {
        public static Error DictationNotFound(Guid DictationId) =>
            Error.NotFound(
                code: "Dictation.NotFound",
                description: $"Dictation with id {DictationId} not found."
            );
    }
}
