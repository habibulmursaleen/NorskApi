using NorskApi.Contracts.Tags.Enums;

namespace NorskApi.Contracts.Tags.Request;

public record UpdateTagRequest(string Label, string Color, TagType TagType);
