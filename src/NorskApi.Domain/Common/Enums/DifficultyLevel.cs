using System.Text.Json.Serialization;

namespace NorskApi.Domain.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DifficultyLevel
{
    ALL,
    A1,
    A2,
    B1,
    B2,
    C1
}
