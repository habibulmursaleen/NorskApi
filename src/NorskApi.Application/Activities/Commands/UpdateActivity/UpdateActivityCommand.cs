using ErrorOr;
using MediatR;
using NorskApi.Application.Activities.Models;
using NorskApi.Domain.ActivityAggregate.Enums;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Activities.Commands.UpdateActivity;

public record UpdateActivityCommand(Guid Id, string Label, ActivityType ActivityType)
    : IRequest<ErrorOr<ActivityResult>>;
