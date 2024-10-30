using FluentValidation;

namespace NorskApi.Application.LocalExpressions.Queries.GetLocalExpressionById;

public class GetLocalExpressionByIdQueryValidator : AbstractValidator<GetLocalExpressionByIdQuery>
{
    public GetLocalExpressionByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Local expression id is required.");
    }
}