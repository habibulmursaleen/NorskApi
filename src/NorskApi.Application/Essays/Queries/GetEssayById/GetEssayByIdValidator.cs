using FluentValidation;

namespace NorskApi.Application.Essays.Queries.GetEssayById;

public class GetEssayByIdQueryValidator : AbstractValidator<GetEssayByIdQuery>
{
    public GetEssayByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Essay id is required.");
    }
}
