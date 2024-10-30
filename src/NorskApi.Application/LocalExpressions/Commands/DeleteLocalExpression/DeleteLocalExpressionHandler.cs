namespace NorskApi.Application.LocalExpressions.Commands.DeleteLocalExpression;
using NorskApi.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Domain.LocalExpressionAggregate;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

public class DeleteLocalExpressionHandler : IRequestHandler<DeleteLocalExpressionCommand, ErrorOr<DeleteLocalExpressionResult>>
{
    private readonly ILocalExpressionRepository localExpressionRepository;

    public DeleteLocalExpressionHandler(ILocalExpressionRepository localExpressionRepository)
    {
        this.localExpressionRepository = localExpressionRepository;
    }

    public async Task<ErrorOr<DeleteLocalExpressionResult>> Handle(DeleteLocalExpressionCommand command, CancellationToken cancellationToken)
    {
        // Use the Create method to create a LocalExpressionId from the Guid
        LocalExpressionId localExpressionId = LocalExpressionId.Create(command.Id);

        LocalExpression? localExpression = await localExpressionRepository.GetById(localExpressionId, cancellationToken);

        if (localExpression is null)
        {
            return Errors.LocalExpressionErrors.LocalExpressionNotFound(command.Id);
        }

        await localExpressionRepository.Delete(localExpression, cancellationToken);

        return new DeleteLocalExpressionResult(localExpression.Id.Value);
    }

}