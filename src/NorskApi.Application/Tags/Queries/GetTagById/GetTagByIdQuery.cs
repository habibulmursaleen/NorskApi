using ErrorOr;
using MediatR;
using NorskApi.Application.Tags.Models;

namespace NorskApi.Application.Tags.Queries.GetTagById;

public record GetTagByIdQuery(Guid Id) : IRequest<ErrorOr<TagResult>>;
