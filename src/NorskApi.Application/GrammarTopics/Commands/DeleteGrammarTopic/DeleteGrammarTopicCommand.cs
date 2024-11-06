namespace NorskApi.Application.GrammarTopics.Commands.DeleteGrammarTopic;

using ErrorOr;
using MediatR;

public record DeleteGrammarTopicCommand(Guid Id) : IRequest<ErrorOr<DeleteGrammarTopicResult>>;
