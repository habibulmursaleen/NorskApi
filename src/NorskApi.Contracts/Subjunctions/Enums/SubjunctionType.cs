using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Subjunctions.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubjunctionType
{
    TIME,
    ARSAK,
    HENSLIKT,
    BETINGELSE,
    MOTSETNING
}
