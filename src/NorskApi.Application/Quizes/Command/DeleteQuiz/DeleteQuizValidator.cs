using FluentValidation;

namespace NorskApi.Application.Quizes.Command.DeleteQuiz;

public class DeleteQuizValidator : AbstractValidator<DeleteQuizCommand>
{
    public DeleteQuizValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
