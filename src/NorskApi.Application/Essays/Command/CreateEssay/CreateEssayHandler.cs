using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Essays.Models;
using NorskApi.Domain.EssayAggregate.Entities;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

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
            command.Activities,
            command.Status,
            command.Notes,
            command.IsCompleted,
            command.IsSaved,
            command.Tags,
            command.DifficultyLevel,
            command
                .Paragraphs.Select(paragraph =>
                    Paragraph.Create(paragraph.Title, paragraph.Content, paragraph.ContentType)
                )
                .ToList(),
            command.RelatedGrammarTopicIds?.Select(TopicId.Create).ToList()
        );

        await this.essayRepository.Add(essay, cancellationToken);

        var result = new EssayResult(
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
        );

        return result;
    }
}
