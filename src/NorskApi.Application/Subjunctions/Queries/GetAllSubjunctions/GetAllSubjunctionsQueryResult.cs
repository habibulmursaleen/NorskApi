using NorskApi.Application.Subjunctions.Models;

namespace NorskApi.Application.Subjunctions.Queries.GetAllSubjunctions;

public record GetAllSubjunctionQueryResult(List<SubjunctionResult> Subjunctions);
