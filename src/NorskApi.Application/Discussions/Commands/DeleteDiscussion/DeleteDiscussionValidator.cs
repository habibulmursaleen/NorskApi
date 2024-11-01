using FluentValidation;

namespace NorskApi.Application.Discussions.Commands.DeleteDiscussion;

public class DeleteDiscussionValidator : AbstractValidator<DeleteDiscussionCommand>
{
    public DeleteDiscussionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull().Must(x => x != Guid.Empty).WithMessage("Id must be a valid guid.");
    }
}