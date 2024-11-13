using ErrorOr;
using MediatR;
using NorskApi.Application.Activities.Models;

namespace NorskApi.Application.Activities.Queries.GetActivityById;

public record GetActivityByIdQuery(Guid Id) : IRequest<ErrorOr<ActivityResult>>;
