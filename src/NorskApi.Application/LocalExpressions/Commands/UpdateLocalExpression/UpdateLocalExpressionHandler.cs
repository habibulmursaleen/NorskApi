using ErrorOr;
using NorskApi.Domain.Common.Errors;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.LocalExpressions.Models;
using NorskApi.Domain.LocalExpressionAggregate;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

namespace NorskApi.Application.LocalExpressions.Commands.UpdateLocalExpression;

public class UpdateLocalExpressionHandler : IRequestHandler<UpdateLocalExpressionCommand, ErrorOr<LocalExpressionResult>>
{
    private readonly ILocalExpressionRepository localExpressionRepository;

    public UpdateLocalExpressionHandler(ILocalExpressionRepository localExpressionRepository)
    {
        this.localExpressionRepository = localExpressionRepository;
    }

    public async Task<ErrorOr<LocalExpressionResult>> Handle(UpdateLocalExpressionCommand command, CancellationToken cancellationToken)
    {
        var id = LocalExpressionId.Create(command.Id);
        LocalExpression? localExpression = await localExpressionRepository.GetById(id, cancellationToken);

        if (localExpression is null)
        {
            return Errors.LocalExpressionErrors.LocalExpressionNotFound(command.Id);
        }

        localExpression.Update(
            command.Label,
            command.Description,
            command.MeaningInNorsk,
            command.MeaningInEnglish,
            command.LocalExpressionType
        );

        await this.localExpressionRepository.Update(localExpression, cancellationToken);

        return new LocalExpressionResult(
            localExpression.Id.Value,
            localExpression.Label,
            localExpression.Description,
            localExpression.MeaningInNorsk,
            localExpression.MeaningInEnglish,
            localExpression.LocalExpressionType,
            localExpression.CreatedDateTime,
            localExpression.UpdatedDateTime
        );
    }
}