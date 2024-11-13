using FluentValidation;
using NorskApi.Domain.TagAggregate.Enums;

namespace NorskApi.Application.Tags.Commands.CreateTag;

public class CreateTagValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagValidator()
    {
        RuleFor(x => x.Label)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Label is required with max 100 character.");

        RuleFor(x => x.Color).NotNull().NotEmpty().WithMessage("Content is required.");

        RuleFor(x => x.TagType.ToString())
            .IsEnumName(typeof(TagType), caseSensitive: false)
            .WithMessage("Invalid TagType.");
    }
}
