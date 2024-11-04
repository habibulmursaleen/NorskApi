using NorskApi.Application.Dictations.Models;

namespace NorskApi.Application.Dictations.Queries.GetAllDictations;

public record GetAllDictationQueryResult(List<DictationResult> Dictations);
