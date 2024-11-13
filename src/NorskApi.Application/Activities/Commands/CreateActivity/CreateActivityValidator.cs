using FluentValidation;
using NorskApi.Domain.ActivityAggregate.Enums;

namespace NorskApi.Application.Activities.Commands.CreateActivity;

public class CreateActivityValidator : AbstractValidator<CreateActivityCommand>
{
    public CreateActivityValidator()
    {
        RuleFor(x => x.Label)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Label is required with max 100 character.");

        RuleFor(x => x.ActivityType.ToString())
            .IsEnumName(typeof(ActivityType), caseSensitive: false)
            .WithMessage("Invalid ActivityType.");
    }
}
