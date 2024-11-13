using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Essays.Models;
using NorskApi.Application.Essays.Queries.GetEssayById;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.Entities;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

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

        return new EssayResult(
            essay.Id.Value,
            essay.Logo,
            essay.Label,
            essay.Description,
            essay.Progress,
            essay.Status,
            essay.Notes,
            essay.IsCompleted,
            essay.IsSaved,
            essay.DifficultyLevel,
            essay.EssayActivityIds.Select(x => new EssayActivityIdsResult(x.Value)).ToList(),
            essay.EssayTagIds.Select(x => new EssayTagIdsResult(x.Value)).ToList(),
            essay
                .EssayRelatedGrammarTopicIds.Select(x => new EssayRelatedGrammarTopicIdsResult(
                    x.Value
                ))
                .ToList(),
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
            essay
                .Roleplays.Select(roleplay => new RoleplayResult(
                    roleplay.Id.Value,
                    roleplay.Content,
                    roleplay.IsCompleted,
                    roleplay.CreatedDateTime,
                    roleplay.UpdatedDateTime
                ))
                .ToList(),
            essay.CreatedDateTime,
            essay.UpdatedDateTime
        );
    }
}
