using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.LocalExpressions.Models;
using NorskApi.Application.LocalExpressions.Queries.GetAllLocalExpressions;

public class GetAllLocalExpressionsQueryHandler : IRequestHandler<GetAllLocalExpressionsQuery, ErrorOr<List<LocalExpressionResult>>>
{
    private readonly ILocalExpressionRepository localExpressionRepository;

    public GetAllLocalExpressionsQueryHandler(ILocalExpressionRepository localExpressionRepository)
    {
        this.localExpressionRepository = localExpressionRepository;
    }

    public async Task<ErrorOr<List<LocalExpressionResult>>> Handle(GetAllLocalExpressionsQuery query, CancellationToken cancellationToken)
    {
        var localExpressions = await this.localExpressionRepository.GetAll(cancellationToken);

        var localExpressionResults = localExpressions
            .Select(localExpression => new LocalExpressionResult(
                localExpression.Id.Value,
                localExpression.Label,
                localExpression.Description,
                localExpression.MeaningInNorsk,
                localExpression.MeaningInEnglish,
                localExpression.LocalExpressionType,
                localExpression.CreatedDateTime,
                localExpression.UpdatedDateTime
            ))
            .ToList();

        return localExpressionResults;
    }
}
