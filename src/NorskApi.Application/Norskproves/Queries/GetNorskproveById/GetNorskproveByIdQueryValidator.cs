using FluentValidation;

namespace NorskApi.Application.Norskproves.Queries.GetNorskproveById;

public class GetNorskproveByIdQueryValidator : AbstractValidator<GetNorskproveByIdQuery>
{
    public GetNorskproveByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Norskprove id is required.");
    }
}
