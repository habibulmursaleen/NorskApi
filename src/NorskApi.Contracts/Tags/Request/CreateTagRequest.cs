using NorskApi.Contracts.Tags.Enums;

namespace NorskApi.Contracts.Tags.Request;

public record CreateTagRequest(string Label, string Color, TagType TagType);
