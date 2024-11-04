namespace NorskApi.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class TaskWorkErrors
    {
        public static Error TaskWorkNotFound(Guid TaskWorkId, Guid Topic) =>
            Error.NotFound(
                code: "404",
                description: $"TaskWork with id {TaskWorkId} or Topic Id {Topic} not found."
            );
    }
}
