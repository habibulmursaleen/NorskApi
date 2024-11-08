using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Essays.Models;
using NorskApi.Application.Essays.Queries.GetAllEssays;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

namespace NorskApi.Application.Essayes.Queries.GetAllEssayes;

public class GetAllEssayesQueryHandler
    : IRequestHandler<GetAllEssaysQuery, ErrorOr<List<EssayResult>>>
{
    private readonly IEssayRepository essayRepository;

    public GetAllEssayesQueryHandler(IEssayRepository essayRepository)
    {
        this.essayRepository = essayRepository;
    }

    public async Task<ErrorOr<List<EssayResult>>> Handle(
        GetAllEssaysQuery query,
        CancellationToken cancellationToken
    )
    {
        List<Essay> essayes = [];
        QueryParamsBaseFilters? filters = query.Filters;
        var essay = await this.essayRepository.GetAll(filters, cancellationToken);

        var essayResult = essay
            .Select(essay => new EssayResult(
                essay.Id.Value,
                essay.Logo,
                essay.Label,
                essay.Description,
                essay.Progress,
                essay.Activities,
                essay.Status,
                essay.Notes,
                essay.IsCompleted,
                essay.IsSaved,
                essay.Tags,
                essay.DifficultyLevel,
                essay.RelatedGrammarTopicIds?.Select(id => TopicId.Create(id)).ToList(),
                essay
                    .Paragraphs.Select(paragraph => new ParagraphResult(
                        paragraph.Id.Value,
                        paragraph.Title,
                        paragraph.Content,
                        paragraph.ContentType,
                        paragraph.CreatedDateTime,
                        paragraph.UpdatedDateTime
                    ))
                    .ToList(),
                essay.CreatedDateTime,
                essay.UpdatedDateTime
            ))
            .ToList();

        return essayResult;
    }
}
