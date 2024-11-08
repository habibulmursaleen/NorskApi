using ErrorOr;

namespace NorskApi.Domain.Common.Errors;

public static partial class Errors
{
    public static class GrammarRulesErrors
    {
        public static Error GrammarRulesNotFound(Guid id) =>
            Error.NotFound(code: "404", description: $"GrammarRules with id {id} not found.");

        public static Error GrammarRulesError(string description) =>
            Error.Conflict(code: "404", description: description);
    }
}
