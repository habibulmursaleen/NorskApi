using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Activities.Enums;

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
