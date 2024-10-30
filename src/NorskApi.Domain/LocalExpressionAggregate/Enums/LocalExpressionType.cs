using System.Text.Json.Serialization;

namespace NorskApi.Domain.LocalExpressionAggregate.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LocalExpressionType
{
    EVERYDAY_PHRASE,
    YOUTH_SLANG,
    PROFESSIONAL,
    PHASES_IDIOMS,
    URBAN_SLANG
}