namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Roleplays.Commands.CreateRoleplay;
using NorskApi.Application.Roleplays.Commands.DeleteRoleplay;
using NorskApi.Application.Roleplays.Commands.UpdateRoleplay;
using NorskApi.Application.Roleplays.Models;
using NorskApi.Application.Roleplays.Queries.GetAllRoleplays;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Roleplays.Request;
using NorskApi.Contracts.Roleplays.Response;

public class RoleplayMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<(Guid essayId, CreateRoleplayRequest request), CreateRoleplayCommand>()
            .Map(dest => dest.EssayId, src => src.essayId)
            .Map(dest => dest.Content, src => src.request.Content)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel);

        config
            .NewConfig<
                (Guid essayId, Guid id, UpdateRoleplayRequest request),
                UpdateRoleplayCommand
            >()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.EssayId, src => src.essayId)
            .Map(dest => dest.Content, src => src.request.Content)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel);

        config.NewConfig<Guid, DeleteRoleplayCommand>().Map(dest => dest.Id, src => src);

        config
            .NewConfig<
                (Guid essayId, QueryParamsBaseFiltersRequest filters),
                GetAllRoleplaysQuery
            >()
            .Map(dest => dest.EssayId, src => src.essayId)
            .Map(dest => dest.Filters, src => src.filters);

        config
            .NewConfig<QueryParamsBaseFiltersRequest, QueryParamsBaseFilters>()
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        config
            .NewConfig<RoleplayResult, RoleplayResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.EssayId, src => src.EssayId)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel);
    }
}
