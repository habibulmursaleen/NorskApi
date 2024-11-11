using FluentValidation;

namespace NorskApi.Application.Words.Queries.GetWordById;

public class GetWordByIdQueryValidator : AbstractValidator<GetWordByIdQuery>
{
    public GetWordByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Word id is required.");
    }
}
