using ErrorOr;
using MediatR;
using NorskApi.Application.Activities.Models;
using NorskApi.Domain.ActivityAggregate.Enums;

namespace NorskApi.Application.Activities.Commands.CreateActivity;

public record CreateActivityCommand(string Label, ActivityType ActivityType)
    : IRequest<ErrorOr<ActivityResult>>;
