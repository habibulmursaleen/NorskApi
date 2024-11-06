namespace NorskApi.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class QuestionErrors
    {
        public static Error QuestionNotFound(Guid QuestionId, Guid EssayId) =>
            Error.NotFound(
                code: "404",
                description: $"Question with id {QuestionId} or essayId {EssayId} not found."
            );
    }
}
