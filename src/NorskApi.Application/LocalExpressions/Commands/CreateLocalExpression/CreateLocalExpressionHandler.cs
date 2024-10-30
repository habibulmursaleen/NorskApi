namespace NorskApi.Application.LocalExpressions.Commands.CreateLocalExpression;

using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.LocalExpressions.Models;
using NorskApi.Domain.LocalExpressionAggregate;
using NorskApi.Domain.LocalExpressionAggregate.Enums;


public class CreateLocalExpressionHandler : IRequestHandler<CreateLocalExpressionCommand, ErrorOr<LocalExpressionResult>>
{
    private readonly ILocalExpressionRepository localExpressionRepository;

    public CreateLocalExpressionHandler(ILocalExpressionRepository localExpressionRepository)
    {
        this.localExpressionRepository = localExpressionRepository;
    }

    public async Task<ErrorOr<LocalExpressionResult>> Handle(CreateLocalExpressionCommand command, CancellationToken cancellationToken)
    {
        LocalExpression localExpression = LocalExpression.Create(
            command.Label,
            command.Description,
            command.MeaningInNorsk,
            command.MeaningInEnglish,
            command.LocalExpressionType
        );

        await this.localExpressionRepository.Add(localExpression, cancellationToken);

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