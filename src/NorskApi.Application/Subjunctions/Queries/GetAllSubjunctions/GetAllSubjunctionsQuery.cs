using ErrorOr;
using MediatR;
using NorskApi.Application.Subjunctions.Models;

namespace NorskApi.Application.Subjunctions.Queries.GetAllSubjunctions;

public record GetAllSubjunctionsQuery : IRequest<ErrorOr<List<SubjunctionResult>>>;
