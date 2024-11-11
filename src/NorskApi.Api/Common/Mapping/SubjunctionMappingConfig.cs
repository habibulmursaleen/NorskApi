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
            .Map(dest => dest.Time, src => src.Time)
            .Map(dest => dest.Arsak, src => src.Arsak)
            .Map(dest => dest.Hensikt, src => src.Hensikt)
            .Map(dest => dest.Betingelse, src => src.Betingelse)
            .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime)
            .Map(dest => dest.UpdatedDateTime, src => src.UpdatedDateTime);
    }
}
