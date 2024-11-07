using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Essay.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContentType
{
    RELATED,
    ADDITIONAL
}
