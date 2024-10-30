using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.LocalExpressions.Models;
using NorskApi.Domain.LocalExpressionAggregate;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

namespace NorskApi.Application.LocalExpressions.Queries.GetLocalExpressionById;

public record GetLocalExpressionByIdQueryHandler : IRequestHandler<GetLocalExpressionByIdQuery, ErrorOr<LocalExpressionResult>>
{
    private readonly ILocalExpressionRepository localExpressionRepository;

    public GetLocalExpressionByIdQueryHandler(ILocalExpressionRepository localExpressionRepository)
    {
        this.localExpressionRepository = localExpressionRepository;
    }

    public async Task<ErrorOr<LocalExpressionResult>> Handle(GetLocalExpressionByIdQuery query, CancellationToken cancellationToken)
    {
        // Use the Create method to create a LocalExpressionId from the Guid
        LocalExpressionId localExpressionId = LocalExpressionId.Create(query.Id);
        LocalExpression? localExpression = await localExpressionRepository.GetById(localExpressionId, cancellationToken);

        if (localExpression is null)
        {
            return Errors.LocalExpressionErrors.LocalExpressionNotFound(query.Id);
        }

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