using FluentValidation;

namespace NorskApi.Application.Roleplays.Commands.DeleteRoleplay;

public class DeleteRoleplayValidator : AbstractValidator<DeleteRoleplayCommand>
{
    public DeleteRoleplayValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
