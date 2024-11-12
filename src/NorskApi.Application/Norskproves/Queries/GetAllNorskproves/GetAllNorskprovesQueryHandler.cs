using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Norskproves.Models;
using NorskApi.Application.Norskproves.Queries.GetAllNorskproves;
using NorskApi.Domain.NorskproveAggregate;

public class GetAllNorskprovesQueryHandler
    : IRequestHandler<GetAllNorskprovesQuery, ErrorOr<List<NorskproveResult>>>
{
    private readonly INorskproveRepository norskproveRepository;

    public GetAllNorskprovesQueryHandler(INorskproveRepository norskproveRepository)
    {
        this.norskproveRepository = norskproveRepository;
    }

    public async Task<ErrorOr<List<NorskproveResult>>> Handle(
        GetAllNorskprovesQuery query,
        CancellationToken cancellationToken
    )
    {
        List<Norskprove> norskproves = new List<Norskprove>();
        QueryParamsBaseFilters filters = query.Filters;

        norskproves = await this.norskproveRepository.GetAll(filters, cancellationToken);

        var norskproveResults = norskproves
            .Select(norskprove => new NorskproveResult(
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
                norskprove
                    .NorskproveTagIds.Select(x => new NorskproveTagIdsResult(x.Value))
                    .ToList(),
                norskprove
                    .ListeningContentIds.Select(x => new ListeningContentIdsResult(x.Value))
                    .ToList(),
                norskprove
                    .ReadingContentIds.Select(x => new ReadingContentIdsResult(x.Value))
                    .ToList(),
                norskprove
                    .WritingContentIds.Select(x => new WritingContentIdsResult(x.Value))
                    .ToList(),
                norskprove
                    .AdditionalGrammarTaskIds.Select(x => new AdditionalGrammarTaskIdsResult(
                        x.Value
                    ))
                    .ToList(),
                norskprove.CreatedDateTime,
                norskprove.UpdatedDateTime
            ))
            .ToList();

        return norskproveResults;
    }
}
