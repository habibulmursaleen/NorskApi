using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Essays.Command.UpdateEssay;
using NorskApi.Application.Essays.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.Entities;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

namespace NorskApi.Application.Essayes.Command.UpdateEssay;

public class UpdateEssayHandler : IRequestHandler<UpdateEssayCommand, ErrorOr<EssayResult>>
{
    private readonly IEssayRepository essayRepository;

    public UpdateEssayHandler(IEssayRepository essayRepository)
    {
        this.essayRepository = essayRepository;
    }

    public async Task<ErrorOr<EssayResult>> Handle(
        UpdateEssayCommand command,
        CancellationToken cancellationToken
    )
    {
        EssayId essayId = EssayId.Create(command.Id);

        Essay? essay = await essayRepository.GetById(essayId, cancellationToken);

        if (essay is null)
        {
            return Errors.EssaysErrors.EssaysNotFound(command.Id);
        }

        List<Paragraph> paragraphsToUpdate = [];

        foreach (UpdateParagraphCommand updateParagraph in command.Paragraphs)
        {
            ParagraphId paragraphId = ParagraphId.Create(updateParagraph.Id);
            Paragraph? paragraph = essay.Paragraphs.FirstOrDefault(paragraph =>
                paragraph.Id == paragraphId
            );

            if (paragraph is null)
            {
                paragraphsToUpdate.Add(
                    Paragraph.Create(
                        updateParagraph.Title,
                        updateParagraph.Content,
                        updateParagraph.ContentType
                    )
                );
            }
            else
            {
                paragraph.Update(
                    updateParagraph.Title,
                    updateParagraph.Content,
                    updateParagraph.ContentType
                );
                paragraphsToUpdate.Add(paragraph);
            }
        }

        var paragraphsToRemove = essay
            .Paragraphs.Where(paragraph =>
                !command.Paragraphs.Any(updateParagraph => updateParagraph.Id == paragraph.Id.Value)
            )
            .ToList();

        paragraphsToUpdate = paragraphsToUpdate
            .Where(paragraph => !paragraphsToRemove.Contains(paragraph))
            .ToList();

        essay.Update(
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
            paragraphsToUpdate,
            command.RelatedGrammarTopicIds?.Select(TopicId.Create).ToList()
        );

        await this.essayRepository.Update(essay, cancellationToken);

        List<ParagraphResult> paragraphsResult = paragraphsToUpdate
            .Select(paragraph => new ParagraphResult(
                paragraph.Id.Value,
                paragraph.Title,
                paragraph.Content,
                paragraph.ContentType,
                paragraph.CreatedDateTime,
                paragraph.UpdatedDateTime
            ))
            .ToList();

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
            paragraphsResult,
            essay.CreatedDateTime,
            essay.UpdatedDateTime
        );
    }
}
