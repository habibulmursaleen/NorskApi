using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Questions.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum QuestionType
{
    SHORT,
    DESCRIPTIVE,
    HYPOTHETICAL,
    GENERAL_KNOWLEDGE
}
