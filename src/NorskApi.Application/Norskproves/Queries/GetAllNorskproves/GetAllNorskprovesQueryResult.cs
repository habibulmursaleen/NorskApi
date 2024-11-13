using NorskApi.Application.Norskproves.Models;

namespace NorskApi.Application.Norskproves.Queries.GetAllNorskproves;

public record GetAllNorskproveQueryResult(List<NorskproveResult> Norskproves);
