namespace NorskApi.Application.Norskproves.Commands.DeleteNorskprove;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.NorskproveAggregate;
using NorskApi.Domain.NorskproveAggregate.ValueObjects;

public class DeleteNorskproveHandler
    : IRequestHandler<DeleteNorskproveCommand, ErrorOr<DeleteNorskproveResult>>
{
    private readonly INorskproveRepository norskproveRepository;

    public DeleteNorskproveHandler(INorskproveRepository norskproveRepository)
    {
        this.norskproveRepository = norskproveRepository;
    }

    public async Task<ErrorOr<DeleteNorskproveResult>> Handle(
        DeleteNorskproveCommand command,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a TopicId from the Guid
        NorskproveId norskproveId = NorskproveId.Create(command.Id);

        Norskprove? norskprove = await norskproveRepository.GetById(
            norskproveId,
            cancellationToken
        );

        if (norskprove is null)
        {
            return Errors.NorskproveErrors.NorskproveNotFound(command.Id);
        }

        await norskproveRepository.Delete(norskprove, cancellationToken);

        return new DeleteNorskproveResult(norskprove.Id.Value);
    }
}
