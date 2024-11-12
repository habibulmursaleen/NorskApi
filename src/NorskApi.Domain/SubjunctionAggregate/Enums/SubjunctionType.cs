using System.Text.Json.Serialization;

namespace NorskApi.Domain.SubjunctionAggregate.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubjunctionType
{
    TIME,
    ARSAK,
    HENSLIKT,
    BETINGELSE,
    MOTSETNING
}
