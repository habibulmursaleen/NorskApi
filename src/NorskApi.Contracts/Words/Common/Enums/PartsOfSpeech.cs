using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Words.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PartOfSpeechTag
{
    NOUN,
    PRONOUN,
    ADVERB,
    ADJECTIVE,
    VERB,
    CONJUNCTION,
    PREPOSITION,
    ARTICLE
}
