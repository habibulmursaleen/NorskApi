using FluentValidation;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.QuestionAggregate.Enums;

namespace NorskApi.Application.Questions.Commands.CreateQuestion;

public class CreateQuestionValidator : AbstractValidator<CreateQuestionCommand>
{
    public CreateQuestionValidator()
    {
        RuleFor(x => x.EssayId)
            .Must(x => x != Guid.Empty)
            .WithMessage("EssayId must be a valid guid.");

        RuleFor(x => x.Label)
            .NotEmpty()
            .WithMessage("Label is required.")
            .MaximumLength(500)
            .WithMessage("Label must not exceed 500 characters.");

        RuleFor(x => x.Answer)
            .MaximumLength(500)
            .WithMessage("Answer must not exceed 500 characters.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleFor(x => x.QuestionType.ToString())
            .IsEnumName(typeof(QuestionType), caseSensitive: false)
            .WithMessage("Invalid QuestionType.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");
    }
}
