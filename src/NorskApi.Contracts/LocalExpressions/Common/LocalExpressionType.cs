using System.Text.Json.Serialization;

namespace NorskApi.Contracts.LocalExpressions.Common;

[JsonConverter(typeof(JsonStringEnumConverter))] // <- Important if you want actual STRING values of ENUM
public enum LocalExpressionType
{
    EVERYDAY_PHRASE,
    YOUTH_SLANG,
    PROFESSIONAL,
    PHASES_IDIOMS,
    URBAN_SLANG
}