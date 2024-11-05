using FluentValidation;

namespace NorskApi.Application.TaskWorks.Commands.DeleteTaskWork;

public class DeleteTaskWorkValidator : AbstractValidator<DeleteTaskWorkCommand>
{
    public DeleteTaskWorkValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
