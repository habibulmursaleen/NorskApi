using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Essays.Models;
using NorskApi.Application.Essays.Queries.GetEssayById;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.Entities;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Application.Essays.Queries.GetEssayById;

public record GetEssayByIdQueryHandler : IRequestHandler<GetEssayByIdQuery, ErrorOr<EssayResult>>
{
    private readonly IEssayRepository essayRepository;

    public GetEssayByIdQueryHandler(IEssayRepository essayRepository)
    {
        this.essayRepository = essayRepository;
    }

    public async Task<ErrorOr<EssayResult>> Handle(
        GetEssayByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a EssayId from the Guid
        EssayId essayId = EssayId.Create(query.Id);
        Essay? essay = await essayRepository.GetById(essayId, cancellationToken);

        if (essay is null)
        {
            return Errors.EssaysErrors.EssaysNotFound(query.Id);
        }

        List<ParagraphResult> paragraphs = [];

        foreach (Paragraph paragraph in essay.Paragraphs)
        {
            paragraphs.Add(
                new ParagraphResult(
                    paragraph.Id.Value,
                    paragraph.Title,
                    paragraph.Content,
                    paragraph.ContentType,
                    paragraph.CreatedDateTime,
                    paragraph.UpdatedDateTime
                )
            );
        }

        return new EssayResult(
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
            essay.RelatedGrammarTopicIds,
            paragraphs,
            essay.CreatedDateTime,
            essay.UpdatedDateTime
        );
    }
}
