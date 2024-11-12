using FluentValidation;

namespace NorskApi.Application.Norskproves.Commands.DeleteNorskprove;

public class DeleteNorskproveValidator : AbstractValidator<DeleteNorskproveCommand>
{
    public DeleteNorskproveValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
