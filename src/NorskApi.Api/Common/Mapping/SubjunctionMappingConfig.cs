namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Subjunctions.Models;
using NorskApi.Contracts.Subjunctions.Response;

public class SubjunctionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Map from SubjunctionResult to SubjunctionResponse
        config
            .NewConfig<SubjunctionResult, SubjunctionResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.SubjunctionType, src => src.SubjunctionType)
            .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime)
            .Map(dest => dest.UpdatedDateTime, src => src.UpdatedDateTime);
    }
}
