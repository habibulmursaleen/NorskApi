namespace NorskApi.Domain.Common.Errors;

using ErrorOr;

public static partial class Errors
{
    public static class LocalExpressionErrors
    {
        public static Error LocalExpressionNotFound(Guid LocalExpressionId) => Error.NotFound(code: "LocalExpression.NotFound", description: $"LocalExpression with id {LocalExpressionId} not found.");
    }
}