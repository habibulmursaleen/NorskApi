using ErrorOr;
using MediatR;
using NorskApi.Application.Roleplays.Models;

namespace NorskApi.Application.Roleplays.Queries.GetRoleplayById;

public record GetRoleplayByIdQuery(Guid EssayId, Guid Id) : IRequest<ErrorOr<RoleplayResult>>;
