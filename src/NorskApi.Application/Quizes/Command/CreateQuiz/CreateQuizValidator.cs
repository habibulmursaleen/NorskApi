using FluentValidation;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.QuizAggregate.Enums;

namespace NorskApi.Application.Quizes.Command.CreateQuiz;

public class CreateQuizValidator : AbstractValidator<CreateQuizCommand>
{
    public CreateQuizValidator()
    {
        RuleFor(x => x.EssayId)
            .Must(x => x == null || x != Guid.Empty)
            .WithMessage("EssayId must be a valid guid.");

        RuleFor(x => x.TopicId)
            .Must(x => x == null || x != Guid.Empty)
            .WithMessage("Topic id must be a valid guid.");

        RuleFor(x => x.DictationId)
            .Must(x => x == null || x != Guid.Empty)
            .WithMessage("Dictation id must be a valid guid.");

        RuleFor(x => x.Question)
            .NotEmpty()
            .WithMessage("Question is required.")
            .MaximumLength(255)
            .WithMessage("Question must not exceed 255 characters.");

        RuleFor(x => x.Answer)
            .NotEmpty()
            .WithMessage("Answer is required.")
            .MaximumLength(500)
            .WithMessage("Answer must not exceed 500 characters.");

        RuleFor(x => x.IsRightAnswer).NotNull().WithMessage("IsRightAnswer is required.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");

        RuleFor(x => x.QuizType.ToString())
            .IsEnumName(typeof(QuizType), caseSensitive: false)
            .WithMessage("Invalid QuizType.");

        RuleForEach(x => x.Options).SetValidator(new CreateQuizOptionCommandValidator());
    }

    public class CreateQuizOptionCommandValidator : AbstractValidator<CreateQuizOptionCommand>
    {
        public CreateQuizOptionCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(255)
                .WithMessage("Title must not exceed 255 characters.");

            RuleFor(x => x.IsCorrect).NotNull().WithMessage("IsCorrect is required.");

            RuleFor(x => x.MultipleChoiceAnswer);
        }
    }
}
