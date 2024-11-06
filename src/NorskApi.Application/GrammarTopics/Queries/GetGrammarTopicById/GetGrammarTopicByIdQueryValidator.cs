using FluentValidation;

namespace NorskApi.Application.GrammarTopics.Queries.GetGrammarTopicById;

public class GetGrammarTopicByIdQueryValidator : AbstractValidator<GetGrammarTopicByIdQuery>
{
    public GetGrammarTopicByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Grammar topic id is required.");
    }
}
