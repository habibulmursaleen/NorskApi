namespace NorskApi.Api.Common.Mapping;

using Mapster;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Norskproves.Commands.CreateNorskprove;
using NorskApi.Application.Norskproves.Commands.DeleteNorskprove;
using NorskApi.Application.Norskproves.Commands.UpdateNorskprove;
using NorskApi.Application.Norskproves.Models;
using NorskApi.Application.Norskproves.Queries.GetAllNorskproves;
using NorskApi.Contracts.Common.QueryParamsRequest;
using NorskApi.Contracts.Norskproves.Request;
using NorskApi.Contracts.Norskproves.Response;

public class NorskproveMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Map from CreateNorskproveRequest to CreateNorskproveCommand
        config
            .NewConfig<CreateNorskproveRequest, CreateNorskproveCommand>()
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.IsSaved, src => src.IsSaved)
            .Map(dest => dest.Progress, src => src.Progress)
            .Map(dest => dest.TimeLimit, src => src.TimeLimit)
            .Map(dest => dest.EstimatedCompletionTime, src => src.EstimatedCompletionTime)
            .Map(dest => dest.Attempts, src => src.Attempts)
            .Map(dest => dest.MaxScore, src => src.MaxScore)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.NorskproveTagIds, src => src.NorskproveTagIds)
            .Map(dest => dest.ListeningContentIds, src => src.ListeningContentIds)
            .Map(dest => dest.ReadingContentIds, src => src.ReadingContentIds)
            .Map(dest => dest.WritingContentIds, src => src.WritingContentIds)
            .Map(dest => dest.AdditionalGrammarTaskIds, src => src.AdditionalGrammarTaskIds);

        // Map from UpdateNorskproveRequest to UpdateNorskproveCommand
        config
            .NewConfig<(Guid id, UpdateNorskproveRequest request), UpdateNorskproveCommand>()
            .Map(dest => dest.Id, src => src.id)
            .Map(dest => dest.Title, src => src.request.Title)
            .Map(dest => dest.Description, src => src.request.Description)
            .Map(dest => dest.IsCompleted, src => src.request.IsCompleted)
            .Map(dest => dest.IsSaved, src => src.request.IsSaved)
            .Map(dest => dest.Progress, src => src.request.Progress)
            .Map(dest => dest.TimeLimit, src => src.request.TimeLimit)
            .Map(dest => dest.EstimatedCompletionTime, src => src.request.EstimatedCompletionTime)
            .Map(dest => dest.Attempts, src => src.request.Attempts)
            .Map(dest => dest.MaxScore, src => src.request.MaxScore)
            .Map(dest => dest.Status, src => src.request.Status)
            .Map(dest => dest.DifficultyLevel, src => src.request.DifficultyLevel)
            .Map(dest => dest.NorskproveTagIds, src => src.request.NorskproveTagIds)
            .Map(dest => dest.ListeningContentIds, src => src.request.ListeningContentIds)
            .Map(dest => dest.ReadingContentIds, src => src.request.ReadingContentIds)
            .Map(dest => dest.WritingContentIds, src => src.request.WritingContentIds)
            .Map(
                dest => dest.AdditionalGrammarTaskIds,
                src => src.request.AdditionalGrammarTaskIds
            );

        // Map from Guid to DeleteNorskproveCommand
        config.NewConfig<Guid, DeleteNorskproveCommand>().Map(dest => dest.Id, src => src);

        config
            .NewConfig<QueryParamsBaseFiltersRequest, GetAllNorskprovesQuery>()
            .Map(dest => dest.Filters, src => src);

        config
            .NewConfig<QueryParamsBaseFiltersRequest, QueryParamsBaseFilters>()
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.Page, src => src.Page)
            .Map(dest => dest.Size, src => src.Size)
            .Map(dest => dest.SortBy, src => src.SortBy);

        // Map from NorskproveResult to NorskproveResponse
        config
            .NewConfig<NorskproveResult, NorskproveResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.IsCompleted, src => src.IsCompleted)
            .Map(dest => dest.IsSaved, src => src.IsSaved)
            .Map(dest => dest.Progress, src => src.Progress)
            .Map(dest => dest.TimeLimit, src => src.TimeLimit)
            .Map(dest => dest.EstimatedCompletionTime, src => src.EstimatedCompletionTime)
            .Map(dest => dest.Attempts, src => src.Attempts)
            .Map(dest => dest.MaxScore, src => src.MaxScore)
            .Map(dest => dest.Status, src => src.Status)
            .Map(dest => dest.DifficultyLevel, src => src.DifficultyLevel)
            .Map(dest => dest.NorskproveTagIds, src => src.NorskproveTagIds)
            .Map(dest => dest.ListeningContentIds, src => src.ListeningContentIds)
            .Map(dest => dest.ReadingContentIds, src => src.ReadingContentIds)
            .Map(dest => dest.WritingContentIds, src => src.WritingContentIds)
            .Map(dest => dest.AdditionalGrammarTaskIds, src => src.AdditionalGrammarTaskIds)
            .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime)
            .Map(dest => dest.UpdatedDateTime, src => src.UpdatedDateTime);
    }
}
