namespace NorskApi.Application.Words.Command.DeleteWord;

using ErrorOr;
using MediatR;

public record DeleteWordCommand(Guid Id) : IRequest<ErrorOr<DeleteWordResult>>;
