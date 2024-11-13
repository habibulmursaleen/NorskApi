using NorskApi.Application.Activities.Models;

namespace NorskApi.Application.Activities.Queries.GetAllActivities;

public record GetAllActivitiesQueryResult(List<ActivityResult> Activitys);
