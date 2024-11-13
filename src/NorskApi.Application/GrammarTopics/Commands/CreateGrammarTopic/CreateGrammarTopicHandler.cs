namespace NorskApi.Application.GrammarTopics.Commands.CreateGrammarTopic;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.GrammarTopics.Models;
using NorskApi.Domain.GrammarTopicAggregate;
using NorskApi.Domain.TagAggregate.ValueObjects;

public class CreateGrammarTopicHandler
    : IRequestHandler<CreateGrammarTopicCommand, ErrorOr<GrammarTopicResult>>
{
    private readonly IGrammarTopicRepository grammarTopicRepository;

    public CreateGrammarTopicHandler(IGrammarTopicRepository grammarTopicRepository)
    {
        this.grammarTopicRepository = grammarTopicRepository;
    }

    public async Task<ErrorOr<GrammarTopicResult>> Handle(
        CreateGrammarTopicCommand command,
        CancellationToken cancellationToken
    )
    {
        GrammarTopic grammarTopic = GrammarTopic.Create(
            command.Label,
            command.Description,
            command.Status,
            command.Chapter,
            command.ModuleCount,
            command.Progress,
            command.IsCompleted,
            command.IsSaved,
            command.GrammarTopicTagIds?.Select(x => TagId.Create(x.TagId)).ToList()
                ?? new List<TagId>(),
            command.DifficultyLevel
        );

        await this.grammarTopicRepository.Add(grammarTopic, cancellationToken);

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
            grammarTopic
                .GrammarTopicTagIds.Select(x => new GrammarTopicTagResult(x.Value))
                .ToList(),
            grammarTopic.DifficultyLevel,
            grammarTopic.CreatedDateTime,
            grammarTopic.UpdatedDateTime
        );
    }
}
