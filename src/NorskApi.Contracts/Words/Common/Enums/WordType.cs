using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Words.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WordType
{
    LOCAL,
    ACADEMIC,
    FORMAL,
    INFORMAL,
    SLANG,
    PHRASE
}
