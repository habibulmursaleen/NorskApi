using System.Text.Json.Serialization;

namespace NorskApi.Domain.ActivityAggregate.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ActivityType
{
    PARAGRAPH,
    TASK,
    DICTATION,
    DISCUSSION,
    VOCABULARY,
    PODCAST,
    QUESTION,
    QUIZ,
    ROLEPLAY,
    GRAMMAR
}
