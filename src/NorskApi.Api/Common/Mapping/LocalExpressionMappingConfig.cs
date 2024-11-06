namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.LocalExpressions.Commands.CreateLocalExpression;
using NorskApi.Application.LocalExpressions.Commands.DeleteLocalExpression;
using NorskApi.Application.LocalExpressions.Commands.UpdateLocalExpression;
using NorskApi.Application.LocalExpressions.Models;
using NorskApi.Contracts.LocalExpressions.Request;
using NorskApi.Contracts.LocalExpressions.Response;

public class LocalExpressionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Map from CreateLocalExpressionRequest to CreateLocalExpressionCommand
        config
            .NewConfig<CreateLocalExpressionRequest, CreateLocalExpressionCommand>()
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.MeaningInNorsk, src => src.MeaningInNorsk)
            .Map(dest => dest.MeaningInEnglish, src => src.MeaningInEnglish)
            .Map(dest => dest.LocalExpressionType, src => src.LocalExpressionType);

        // Map from UpdateLocalExpressionRequest to UpdateLocalExpressionCommand
        config
            .NewConfig<
                (Guid id, UpdateLocalExpressionRequest request),
                UpdateLocalExpressionCommand
            >()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.Label, src => src.request.Label)
            .Map(dest => dest.Description, src => src.request.Description)
            .Map(dest => dest.MeaningInNorsk, src => src.request.MeaningInNorsk)
            .Map(dest => dest.MeaningInEnglish, src => src.request.MeaningInEnglish)
            .Map(dest => dest.LocalExpressionType, src => src.request.LocalExpressionType);

        // Map from Guid to DeleteLocalExpressionCommand
        config.NewConfig<Guid, DeleteLocalExpressionCommand>().Map(dest => dest.Id, src => src);

        // Map from LocalExpressionResult to LocalExpressionResponse
        config
            .NewConfig<LocalExpressionResult, LocalExpressionResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Label, src => src.Label)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.MeaningInNorsk, src => src.MeaningInNorsk)
            .Map(dest => dest.MeaningInEnglish, src => src.MeaningInEnglish)
            .Map(dest => dest.LocalExpressionType, src => src.LocalExpressionType)
            .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime)
            .Map(dest => dest.UpdatedDateTime, src => src.UpdatedDateTime);
    }
}
