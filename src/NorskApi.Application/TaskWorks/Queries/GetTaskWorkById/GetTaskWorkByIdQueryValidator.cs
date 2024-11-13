using FluentValidation;
using NorskApi.Application.TaskWorks.Queries.GetTaskById;

namespace NorskApi.Application.TaskWorks.Queries.GetTaskWorkById;

public class GetTaskWorkByIdQueryValidator : AbstractValidator<GetTaskWorkByIdQuery>
{
    public GetTaskWorkByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Task id is required and must be valid guid.");
    }
}
