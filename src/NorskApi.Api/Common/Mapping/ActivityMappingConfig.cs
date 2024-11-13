namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Activities.Commands.CreateActivity;
using NorskApi.Application.Activities.Commands.DeleteActivity;
using NorskApi.Application.Activities.Commands.UpdateActivity;
using NorskApi.Application.Activities.Models;
using NorskApi.Contracts.Activities.Request;
using NorskApi.Contracts.Activities.Response;

public class ActivityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<CreateActivityRequest, CreateActivityCommand>()
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.ActivityType, src => src.ActivityType);

        config
            .NewConfig<(Guid id, UpdateActivityRequest request), UpdateActivityCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.ActivityType, src => src.request.ActivityType);

        config.NewConfig<Guid, DeleteActivityCommand>().Map(dest => dest.Id, src => src);

        config
            .NewConfig<ActivityResult, ActivityResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.ActivityType, src => src.ActivityType);
    }
}
