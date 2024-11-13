namespace NorskApi.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class NorskproveErrors
    {
        public static Error NorskproveNotFound(Guid NorskproveId) =>
            Error.NotFound(
                code: "404",
                description: $"Norskprove with id {NorskproveId} not found."
            );
    }
}
