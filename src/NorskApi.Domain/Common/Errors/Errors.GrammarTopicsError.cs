namespace NorskApi.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class GrammarTopicErrors
    {
        public static Error GrammarTopicNotFound(Guid GrammarTopicId) =>
            Error.NotFound(
                code: "404",
                description: $"GrammarTopic with id {GrammarTopicId} not found."
            );
    }
}
