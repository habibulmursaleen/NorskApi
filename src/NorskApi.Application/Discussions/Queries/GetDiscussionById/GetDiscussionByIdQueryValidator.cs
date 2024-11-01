using FluentValidation;

namespace NorskApi.Application.Discussions.Queries.GetDiscussionById;

public class GetDiscussionByIdQueryValidator : AbstractValidator<GetDiscussionByIdQuery>
{
    public GetDiscussionByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Discussion id is required and must be valid guid.");
    }
}