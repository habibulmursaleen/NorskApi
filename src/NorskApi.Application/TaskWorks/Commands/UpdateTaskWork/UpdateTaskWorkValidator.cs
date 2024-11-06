using FluentValidation;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.TaskWorks.Commands.UpdateTaskWork;

public class UpdateTaskWorkValidator : AbstractValidator<UpdateTaskWorkCommand>
{
    public UpdateTaskWorkValidator()
    {
        RuleFor(x => x.TopicId)
            .Must(x => x != Guid.Empty)
            .WithMessage("Topic Id must be a valid guid.");

        RuleFor(x => x.Logo).NotEmpty().WithMessage("Logo must not exceed 255 characters.");

        RuleFor(x => x.Label)
            .NotEmpty()
            .WithMessage("Label is required.")
            .MaximumLength(255)
            .WithMessage("Label must not exceed 255 characters.");

        RuleFor(x => x.TaskPointer).NotEmpty().WithMessage("TaskPointer is required.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleFor(x => x.Answer).NotEmpty().WithMessage("Answer is required.");

        RuleFor(x => x.Comments).NotEmpty().WithMessage("Comments is required.");

        RuleFor(x => x.AdditionalInfo).NotEmpty().WithMessage("AdditionalInfo is required.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");
    }
}
