using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.GrammarTopics.Models;
using NorskApi.Application.GrammarTopics.Queries.GetAllGrammarTopics;
using NorskApi.Domain.GrammarTopicAggregate;

public class GetAllGrammarTopicsQueryHandler
    : IRequestHandler<GetAllGrammarTopicsQuery, ErrorOr<List<GrammarTopicResult>>>
{
    private readonly IGrammarTopicRepository grammarTopicRepository;

    public GetAllGrammarTopicsQueryHandler(IGrammarTopicRepository grammarTopicRepository)
    {
        this.grammarTopicRepository = grammarTopicRepository;
    }

    public async Task<ErrorOr<List<GrammarTopicResult>>> Handle(
        GetAllGrammarTopicsQuery query,
        CancellationToken cancellationToken
    )
    {
        List<GrammarTopic> grammarTopics = new List<GrammarTopic>();
        QueryParamsBaseFilters filters = query.Filters;

        grammarTopics = await this.grammarTopicRepository.GetAll(filters, cancellationToken);

        var grammarTopicResults = grammarTopics
            .Select(grammarTopic => new GrammarTopicResult(
                grammarTopic.Id.Value,
                grammarTopic.Label,
                grammarTopic.Description ?? string.Empty,
                grammarTopic.Status,
                grammarTopic.Chapter,
                grammarTopic.ModuleCount,
                grammarTopic.Progress,
                grammarTopic.IsCompleted,
                grammarTopic.IsSaved,
                grammarTopic.Tags ?? [],
                grammarTopic.DifficultyLevel,
                grammarTopic.CreatedDateTime,
                grammarTopic.UpdatedDateTime
            ))
            .ToList();

        return grammarTopicResults;
    }
}
