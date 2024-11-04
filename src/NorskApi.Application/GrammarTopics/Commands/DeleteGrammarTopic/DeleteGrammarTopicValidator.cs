using FluentValidation;

namespace NorskApi.Application.GrammarTopics.Commands.DeleteGrammarTopic;

public class DeleteGrammarTopicValidator : AbstractValidator<DeleteGrammarTopicCommand>
{
    public DeleteGrammarTopicValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
