using System.Text.Json.Serialization;

namespace NorskApi.Domain.EssayAggregate.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContentType
{
    RELATED,
    ADDITIONAL
}
