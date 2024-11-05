using FluentValidation;

namespace NorskApi.Application.Questions.Commands.DeleteQuestion;

public class DeleteQuestionValidator : AbstractValidator<DeleteQuestionCommand>
{
    public DeleteQuestionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
