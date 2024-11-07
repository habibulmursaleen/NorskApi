namespace NorskApi.Application.Essays.Command.DeleteEssay;

using ErrorOr;
using MediatR;

public record DeleteEssayCommand(Guid Id) : IRequest<ErrorOr<DeleteEssayResult>>;
