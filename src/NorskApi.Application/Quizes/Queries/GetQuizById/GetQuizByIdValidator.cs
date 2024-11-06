using FluentValidation;

namespace NorskApi.Application.Quizes.Queries.GetQuizById;

public class GetQuizByIdQueryValidator : AbstractValidator<GetQuizByIdQuery>
{
    public GetQuizByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Quiz id is required.");
    }
}
