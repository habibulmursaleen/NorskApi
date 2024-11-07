using FluentValidation;

namespace NorskApi.Application.Essays.Command.DeleteEssay;

public class DeleteEssayValidator : AbstractValidator<DeleteEssayCommand>
{
    public DeleteEssayValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
