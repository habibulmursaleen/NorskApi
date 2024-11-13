using FluentValidation;

namespace NorskApi.Application.Tags.Commands.DeleteTag;

public class DeleteTagValidator : AbstractValidator<DeleteTagCommand>
{
    public DeleteTagValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
