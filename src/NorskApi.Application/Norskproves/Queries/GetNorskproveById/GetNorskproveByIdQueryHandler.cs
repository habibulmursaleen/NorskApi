using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Norskproves.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.NorskproveAggregate;
using NorskApi.Domain.NorskproveAggregate.ValueObjects;

namespace NorskApi.Application.Norskproves.Queries.GetNorskproveById;

public record GetNorskproveByIdQueryHandler
    : IRequestHandler<GetNorskproveByIdQuery, ErrorOr<NorskproveResult>>
{
    private readonly INorskproveRepository norskproveRepository;

    public GetNorskproveByIdQueryHandler(INorskproveRepository norskproveRepository)
    {
        this.norskproveRepository = norskproveRepository;
    }

    public async Task<ErrorOr<NorskproveResult>> Handle(
        GetNorskproveByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a TopicId from the Guid
        NorskproveId norskproveId = NorskproveId.Create(query.Id);
        Norskprove? norskprove = await norskproveRepository.GetById(
            norskproveId,
            cancellationToken
        );

        if (norskprove is null)
        {
            return Errors.NorskproveErrors.NorskproveNotFound(query.Id);
        }

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
