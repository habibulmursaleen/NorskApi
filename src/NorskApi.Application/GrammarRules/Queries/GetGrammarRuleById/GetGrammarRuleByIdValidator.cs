using FluentValidation;

namespace NorskApi.Application.GrammarRules.Queries.GetGrammarRuleById;

public class GetGrammarRuleByIdQueryValidator : AbstractValidator<GetGrammarRuleByIdQuery>
{
    public GetGrammarRuleByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("GrammarRule id is required.");
    }
}
