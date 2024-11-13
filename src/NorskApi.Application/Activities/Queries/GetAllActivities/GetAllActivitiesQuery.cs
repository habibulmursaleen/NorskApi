using ErrorOr;
using MediatR;
using NorskApi.Application.Activities.Models;

namespace NorskApi.Application.Activities.Queries.GetAllActivities;

public record GetAllActivitiesQuery() : IRequest<ErrorOr<List<ActivityResult>>>;
