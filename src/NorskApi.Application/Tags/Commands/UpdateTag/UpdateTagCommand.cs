using ErrorOr;
using MediatR;
using NorskApi.Application.Tags.Models;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.TagAggregate.Enums;

namespace NorskApi.Application.Tags.Commands.UpdateTag;

public record UpdateTagCommand(Guid Id, string Label, string Color, TagType TagType)
    : IRequest<ErrorOr<TagResult>>;
