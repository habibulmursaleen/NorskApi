using ErrorOr;
using MediatR;
using NorskApi.Application.GrammarTopics.Models;

namespace NorskApi.Application.GrammarTopics.Queries.GetGrammarTopicById;

public record GetGrammarTopicByIdQuery(Guid Id) : IRequest<ErrorOr<GrammarTopicResult>>;
