using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Tags.Models;

namespace NorskApi.Application.Tags.Queries.GetAllTags;

public record GetAllTagsQuery(TagsQueryParamsFilters Filters) : IRequest<ErrorOr<List<TagResult>>>;
