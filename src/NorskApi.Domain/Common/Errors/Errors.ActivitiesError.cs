namespace NorskApi.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class ActivityErrors
    {
        public static Error ActivityNotFound(Guid ActivityId) =>
            Error.NotFound(code: "404", description: $"Activity with id {ActivityId} not found.");
    }
}
