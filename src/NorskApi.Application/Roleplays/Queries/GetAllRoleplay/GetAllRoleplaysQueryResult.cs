using NorskApi.Application.Roleplays.Models;

namespace NorskApi.Application.Roleplays.Queries.GetAllRoleplays;

public record GetAllRoleplayQueryResult(List<RoleplayResult> Roleplays);
