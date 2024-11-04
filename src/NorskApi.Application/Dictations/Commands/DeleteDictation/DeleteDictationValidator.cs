using FluentValidation;

namespace NorskApi.Application.Dictations.Commands.DeleteDictation;

public class DeleteDictationValidator : AbstractValidator<DeleteDictationCommand>
{
    public DeleteDictationValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
