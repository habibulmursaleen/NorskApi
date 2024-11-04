using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    ACTIVE,
    INACTIVE
}
