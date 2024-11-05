using FluentValidation;

namespace NorskApi.Application.Roleplays.Queries.GetRoleplayById;

public class GetRoleplayByIdQueryValidator : AbstractValidator<GetRoleplayByIdQuery>
{
    public GetRoleplayByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Roleplay id is required and must be valid guid.");
    }
}
