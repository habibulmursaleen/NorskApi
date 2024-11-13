using NorskApi.Application.Tags.Models;

namespace NorskApi.Application.Tags.Queries.GetAllTags;

public record GetAllTagQueryResult(List<TagResult> Tags);
