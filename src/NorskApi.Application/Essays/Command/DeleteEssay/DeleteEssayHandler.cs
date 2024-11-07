namespace NorskApi.Application.Essayes.Command.DeleteEssay;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Essays.Command.DeleteEssay;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.EssayAggregate.ValueObjects;

public class DeleteEssayHandler : IRequestHandler<DeleteEssayCommand, ErrorOr<DeleteEssayResult>>
{
    private readonly IEssayRepository essayRepository;

    public DeleteEssayHandler(IEssayRepository essayRepository)
    {
        this.essayRepository = essayRepository;
    }

    public async Task<ErrorOr<DeleteEssayResult>> Handle(
        DeleteEssayCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a EssayId from the Guid
        EssayId essayId = EssayId.Create(command.Id);

        Essay? essay = await essayRepository.GetById(essayId, cancellationToken);

        if (essay is null)
        {
            return Errors.EssaysErrors.EssaysNotFound(command.Id);
        }

        essay.Delete();

        await essayRepository.Delete(essay, cancellationToken);

        return new DeleteEssayResult(essay.Id.Value);
    }
}
