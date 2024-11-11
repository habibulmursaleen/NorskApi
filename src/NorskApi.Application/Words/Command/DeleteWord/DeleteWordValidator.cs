using FluentValidation;

namespace NorskApi.Application.Words.Command.DeleteWord;

public class DeleteWordValidator : AbstractValidator<DeleteWordCommand>
{
    public DeleteWordValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
