namespace NorskApi.Application.GrammarTopics.Commands.DeleteGrammarTopic;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.GrammarTopicAggregate;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

public class DeleteGrammarTopicHandler
    : IRequestHandler<DeleteGrammarTopicCommand, ErrorOr<DeleteGrammarTopicResult>>
{
    private readonly IGrammarTopicRepository grammarTopicRepository;

    public DeleteGrammarTopicHandler(IGrammarTopicRepository grammarTopicRepository)
    {
        this.grammarTopicRepository = grammarTopicRepository;
    }

    public async Task<ErrorOr<DeleteGrammarTopicResult>> Handle(
        DeleteGrammarTopicCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a TopicId from the Guid
        TopicId topicId = TopicId.Create(command.Id);

        GrammarTopic? grammarTopic = await grammarTopicRepository.GetById(
            topicId,
            cancellationToken
        );

        if (grammarTopic is null)
        {
            return Errors.GrammarTopicErrors.GrammarTopicNotFound(command.Id);
        }

        await grammarTopicRepository.Delete(grammarTopic, cancellationToken);

        return new DeleteGrammarTopicResult(grammarTopic.Id.Value);
    }
}
