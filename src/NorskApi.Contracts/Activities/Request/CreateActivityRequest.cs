using NorskApi.Contracts.Activities.Enums;

namespace NorskApi.Contracts.Activities.Request;

public record CreateActivityRequest(string Label, ActivityType ActivityType);
