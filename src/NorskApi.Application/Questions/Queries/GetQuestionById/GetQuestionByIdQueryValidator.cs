using FluentValidation;

namespace NorskApi.Application.Questions.Queries.GetQuestionById;

public class GetQuestionByIdQueryValidator : AbstractValidator<GetQuestionByIdQuery>
{
    public GetQuestionByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Question id is required and must be valid guid.");
    }
}
