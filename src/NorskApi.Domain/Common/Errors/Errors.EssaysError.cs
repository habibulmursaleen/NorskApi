using ErrorOr;

namespace NorskApi.Domain.Common.Errors;

public static partial class Errors
{
    public static class EssaysErrors
    {
        public static Error EssaysNotFound(Guid id) =>
            Error.NotFound(code: "404", description: $"Essays with id {id} not found.");

        public static Error EssaysError(string description) =>
            Error.Conflict(code: "404", description: description);
    }
}
