using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DifficultyLevel
{
    A1,
    A2,
    B1,
    B2,
    C1
}