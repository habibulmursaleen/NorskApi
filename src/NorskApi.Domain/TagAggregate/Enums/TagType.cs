using System.Text.Json.Serialization;

namespace NorskApi.Domain.TagAggregate.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TagType
{
    ESSAY,
    GRAMMAR_TOPIC,
    GRAMMAR_RULE
}
