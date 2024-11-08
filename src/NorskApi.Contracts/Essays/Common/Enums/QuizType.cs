using System.Text.Json.Serialization;

namespace NorskApi.Contracts.Essays.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContentType
{
    RELATED,
    ADDITIONAL
}
