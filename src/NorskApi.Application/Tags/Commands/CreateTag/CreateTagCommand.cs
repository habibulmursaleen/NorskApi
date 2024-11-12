using ErrorOr;
using MediatR;
using NorskApi.Application.Tags.Models;
using NorskApi.Domain.TagAggregate.Enums;

namespace NorskApi.Application.Tags.Commands.CreateTag;

public record CreateTagCommand(string Label, string Color, TagType TagType)
    : IRequest<ErrorOr<TagResult>>;
