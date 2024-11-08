using FluentValidation;

namespace NorskApi.Application.GrammarRules.Command.DeleteGrammarRule;

public class DeleteGrammarRuleValidator : AbstractValidator<DeleteGrammarRuleCommand>
{
    public DeleteGrammarRuleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
