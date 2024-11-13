using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Tags.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TagType
{
    ESSAY,
    GRAMMAR_TOPIC,
    GRAMMAR_RULE
}
