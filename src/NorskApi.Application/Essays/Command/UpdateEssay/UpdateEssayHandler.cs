using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Essays.Command.UpdateEssay;
using NorskApi.Application.Essays.Models;
using NorskApi.Domain.ActivityAggregate.ValueObjects;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.Entities;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TagAggregate.ValueObjects;

namespace NorskApi.Application.Essays.Command.UpdateEssay;

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
        List<Roleplay> roleplaysToUpdate = [];

        if (command.Paragraphs is not null)
        {
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
        }

        var paragraphsToRemove = essay
            .Paragraphs.Where(paragraph =>
                command.Paragraphs != null
                && !command.Paragraphs.Any(updateParagraph =>
                    updateParagraph.Id == paragraph.Id.Value
                )
            )
            .ToList();

        paragraphsToUpdate = paragraphsToUpdate
            .Where(paragraph => !paragraphsToRemove.Contains(paragraph))
            .ToList();

        if (command.Roleplays is not null)
        {
            foreach (UpdateRoleplayCommand updateRoleplay in command.Roleplays)
            {
                RoleplayId roleplayId = RoleplayId.Create(updateRoleplay.Id);
                Roleplay? roleplay = essay.Roleplays.FirstOrDefault(roleplay =>
                    roleplay.Id == roleplayId
                );

                if (roleplay is null)
                {
                    roleplaysToUpdate.Add(
                        Roleplay.Create(updateRoleplay.Content, updateRoleplay.IsCompleted)
                    );
                }
                else
                {
                    roleplay.Update(updateRoleplay.Content, updateRoleplay.IsCompleted);
                    roleplaysToUpdate.Add(roleplay);
                }
            }
        }

        var roleplaysToRemove = essay
            .Roleplays.Where(roleplay =>
                command.Roleplays != null
                && !command.Roleplays.Any(updateRoleplay => updateRoleplay.Id == roleplay.Id.Value)
            )
            .ToList();

        roleplaysToUpdate = roleplaysToUpdate
            .Where(roleplay => !roleplaysToRemove.Contains(roleplay))
            .ToList();

        essay.Update(
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
            paragraphsToUpdate,
            roleplaysToUpdate
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
