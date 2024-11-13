using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Norskproves.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.DictationAggregate.ValueObjects;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.NorskproveAggregate;
using NorskApi.Domain.NorskproveAggregate.ValueObjects;
using NorskApi.Domain.QuestionAggregate.ValueObjects;
using NorskApi.Domain.TagAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate.ValueObjects;

namespace NorskApi.Application.Norskproves.Commands.UpdateNorskprove;

public class UpdateNorskproveHandler
    : IRequestHandler<UpdateNorskproveCommand, ErrorOr<NorskproveResult>>
{
    private readonly INorskproveRepository norskproveRepository;

    public UpdateNorskproveHandler(INorskproveRepository norskproveRepository)
    {
        this.norskproveRepository = norskproveRepository;
    }

    public async Task<ErrorOr<NorskproveResult>> Handle(
        UpdateNorskproveCommand command,
        CancellationToken cancellationToken
    )
    {
        var id = NorskproveId.Create(command.Id);
        Norskprove? norskprove = await norskproveRepository.GetById(id, cancellationToken);

        if (norskprove is null)
        {
            return Errors.NorskproveErrors.NorskproveNotFound(command.Id);
        }

        norskprove.Update(
            command.Title,
            command.Description,
            command.IsCompleted,
            command.IsSaved,
            command.Progress,
            command.TimeLimit,
            command.EstimatedCompletionTime,
            command.Attempts,
            command.MaxScore,
            command.Status,
            command.DifficultyLevel,
            command.NorskproveTagIds?.Select(x => TagId.Create(x.TagId)).ToList()
                ?? new List<TagId>(),
            command.SpeakingContentIds?.Select(x => QuestionId.Create(x.QuestionId)).ToList()
                ?? new List<QuestionId>(),
            command.ListeningContentIds?.Select(x => DictationId.Create(x.DictationId)).ToList()
                ?? new List<DictationId>(),
            command.ReadingContentIds?.Select(x => EssayId.Create(x.EssayId)).ToList()
                ?? new List<EssayId>(),
            command.WritingContentIds?.Select(x => DiscussionId.Create(x.DiscussionId)).ToList()
                ?? new List<DiscussionId>(),
            command.AdditionalGrammarTaskIds?.Select(x => TaskWorkId.Create(x.TaskWorkId)).ToList()
                ?? new List<TaskWorkId>()
        );

        await this.norskproveRepository.Update(norskprove, cancellationToken);

        return new NorskproveResult(
            norskprove.Id.Value,
            norskprove.Title,
            norskprove.Description,
            norskprove.IsCompleted,
            norskprove.IsSaved,
            norskprove.Progress,
            norskprove.TimeLimit,
            norskprove.EstimatedCompletionTime,
            norskprove.Attempts,
            norskprove.MaxScore,
            norskprove.Status,
            norskprove.DifficultyLevel,
            norskprove.NorskproveTagIds.Select(x => new NorskproveTagIdsResult(x.Value)).ToList(),
            norskprove
                .SpeakingContentIds.Select(x => new SpeakingContentIdsResult(x.Value))
                .ToList(),
            norskprove
                .ListeningContentIds.Select(x => new ListeningContentIdsResult(x.Value))
                .ToList(),
            norskprove.ReadingContentIds.Select(x => new ReadingContentIdsResult(x.Value)).ToList(),
            norskprove.WritingContentIds.Select(x => new WritingContentIdsResult(x.Value)).ToList(),
            norskprove
                .AdditionalGrammarTaskIds.Select(x => new AdditionalGrammarTaskIdsResult(x.Value))
                .ToList(),
            norskprove.CreatedDateTime,
            norskprove.UpdatedDateTime
        );
    }
}
