using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Quizes.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum QuizType
{
    MultipleChoice,
    TrueFalse,
    FillInTheBlank,
    Essay
}
