using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.GrammarTopics.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.GrammarTopicAggregate;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

namespace NorskApi.Application.GrammarTopics.Queries.GetGrammarTopicById;

public record GetGrammarTopicByIdQueryHandler
    : IRequestHandler<GetGrammarTopicByIdQuery, ErrorOr<GrammarTopicResult>>
{
    private readonly IGrammarTopicRepository grammarTopicRepository;

    public GetGrammarTopicByIdQueryHandler(IGrammarTopicRepository grammarTopicRepository)
    {
        this.grammarTopicRepository = grammarTopicRepository;
    }

    public async Task<ErrorOr<GrammarTopicResult>> Handle(
        GetGrammarTopicByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a TopicId from the Guid
        TopicId topicId = TopicId.Create(query.Id);
        GrammarTopic? grammarTopic = await grammarTopicRepository.GetById(
            topicId,
            cancellationToken
        );

        if (grammarTopic is null)
        {
            return Errors.GrammarTopicErrors.GrammarTopicNotFound(query.Id);
        }

        return new GrammarTopicResult(
            grammarTopic.Id.Value,
            grammarTopic.Label,
            grammarTopic.Description ?? string.Empty,
            grammarTopic.Status,
            grammarTopic.Chapter,
            grammarTopic.ModuleCount,
            grammarTopic.Progress,
            grammarTopic.IsCompleted,
            grammarTopic.IsSaved,
            grammarTopic.Tags ?? new List<string>(),
            grammarTopic.DifficultyLevel,
            grammarTopic.CreatedDateTime,
            grammarTopic.UpdatedDateTime
        );
    }
}
