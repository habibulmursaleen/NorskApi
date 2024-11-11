using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Words.Models;

namespace NorskApi.Application.Words.Queries.GetAllWords;

public record GetAllWordsQuery(QueryParamsWithEssayFilters Filters)
    : IRequest<ErrorOr<List<WordResult>>>;
