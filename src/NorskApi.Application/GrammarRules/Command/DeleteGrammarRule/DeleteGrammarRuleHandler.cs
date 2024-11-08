namespace NorskApi.Application.GrammarRules.Command.DeleteGrammarRule;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

public class DeleteGrammarRuleHandler
    : IRequestHandler<DeleteGrammarRuleCommand, ErrorOr<DeleteGrammarRuleResult>>
{
    private readonly IGrammarRuleRepository grammarRuleRepository;

    public DeleteGrammarRuleHandler(IGrammarRuleRepository grammarRuleRepository)
    {
        this.grammarRuleRepository = grammarRuleRepository;
    }

    public async Task<ErrorOr<DeleteGrammarRuleResult>> Handle(
        DeleteGrammarRuleCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a GrammarRuleId from the Guid
        GrammarRuleId grammarRuleId = GrammarRuleId.Create(command.Id);
        TopicId topicId = TopicId.Create(command.TopicId);

        GrammarRule? grammarRule = await grammarRuleRepository.GetById(
            topicId,
            grammarRuleId,
            cancellationToken
        );

        if (grammarRule is null)
        {
            return Errors.GrammarRulesErrors.GrammarRulesNotFound(command.Id);
        }

        grammarRule.Delete();

        await grammarRuleRepository.Delete(grammarRule, cancellationToken);

        return new DeleteGrammarRuleResult(grammarRule.Id.Value);
    }
}
