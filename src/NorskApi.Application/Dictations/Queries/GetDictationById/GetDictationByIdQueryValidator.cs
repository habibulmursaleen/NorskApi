using FluentValidation;

namespace NorskApi.Application.Dictations.Queries.GetDictationById;

public class GetDictationByIdQueryValidator : AbstractValidator<GetDictationByIdQuery>
{
    public GetDictationByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Local expression id is required.");
    }
}
