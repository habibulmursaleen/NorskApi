using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.GrammarTopics.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.GrammarTopicAggregate;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

namespace NorskApi.Application.GrammarTopics.Commands.UpdateGrammarTopic;

public class UpdateGrammarTopicHandler
    : IRequestHandler<UpdateGrammarTopicCommand, ErrorOr<GrammarTopicResult>>
{
    private readonly IGrammarTopicRepository grammarTopicRepository;

    public UpdateGrammarTopicHandler(IGrammarTopicRepository grammarTopicRepository)
    {
        this.grammarTopicRepository = grammarTopicRepository;
    }

    public async Task<ErrorOr<GrammarTopicResult>> Handle(
        UpdateGrammarTopicCommand command,
        CancellationToken cancellationToken
    )
    {
        var id = TopicId.Create(command.Id);
        GrammarTopic? grammarTopic = await grammarTopicRepository.GetById(id, cancellationToken);

        if (grammarTopic is null)
        {
            return Errors.GrammarTopicErrors.GrammarTopicNotFound(command.Id);
        }

        grammarTopic.Update(
            command.Label,
            command.Description,
            command.Status,
            command.Chapter,
            command.ModuleCount,
            command.Progress,
            command.IsCompleted,
            command.IsSaved,
            command.Tags,
            command.DifficultyLevel
        );

        await this.grammarTopicRepository.Update(grammarTopic, cancellationToken);

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
