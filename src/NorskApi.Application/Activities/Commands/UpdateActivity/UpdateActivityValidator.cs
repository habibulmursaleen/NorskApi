using FluentValidation;
using NorskApi.Domain.ActivityAggregate.Enums;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Activities.Commands.UpdateActivity;

public class UpdateActivityValidator : AbstractValidator<UpdateActivityCommand>
{
    public UpdateActivityValidator()
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
