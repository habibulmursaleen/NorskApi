using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Essays.Models;
using NorskApi.Domain.ActivityAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.Entities;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TagAggregate.ValueObjects;

namespace NorskApi.Application.Essays.Command.CreateEssay;

public class CreateEssayHandler : IRequestHandler<CreateEssayCommand, ErrorOr<EssayResult>>
{
    private readonly IEssayRepository essayRepository;

    public CreateEssayHandler(IEssayRepository essayRepository)
    {
        this.essayRepository = essayRepository;
    }

    public async Task<ErrorOr<EssayResult>> Handle(
        CreateEssayCommand command,
        CancellationToken cancellationToken
    )
    {
        Essay essay = Essay.Create(
            command.Logo,
            command.Label,
            command.Description,
            command.Progress,
            command.Status,
            command.Notes,
            command.IsCompleted,
            command.IsSaved,
            command.DifficultyLevel,
            command.EssayActivityIds?.Select(x => ActivityId.Create(x.ActivityId)).ToList()
                ?? new List<ActivityId>(),
            command.EssayTagIds?.Select(x => TagId.Create(x.TagId)).ToList() ?? new List<TagId>(),
            command.EssayRelatedGrammarTopicIds?.Select(x => TopicId.Create(x.TopicId)).ToList()
                ?? new List<TopicId>(),
            command
                .Paragraphs?.Select(option =>
                    Paragraph.Create(option.Title, option.Content, option.ContentType)
                )
                .ToList() ?? new List<Paragraph>(),
            command
                .Roleplays?.Select(option => Roleplay.Create(option.Content, option.IsCompleted))
                .ToList() ?? new List<Roleplay>()
        );

        await this.essayRepository.Add(essay, cancellationToken);

        var result = new EssayResult(
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

        return result;
    }
}
