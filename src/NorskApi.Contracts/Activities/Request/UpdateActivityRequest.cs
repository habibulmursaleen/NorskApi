using NorskApi.Contracts.Activities.Enums;

namespace NorskApi.Contracts.Activities.Request;

public record UpdateActivityRequest(string Label, ActivityType ActivityType);
