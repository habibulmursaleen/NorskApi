using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Roleplays.Models;

namespace NorskApi.Application.Roleplays.Queries.GetAllRoleplays;

public record GetAllRoleplaysQuery(Guid? EssayId, QueryParamsBaseFilters Filters)
    : IRequest<ErrorOr<List<RoleplayResult>>>;
