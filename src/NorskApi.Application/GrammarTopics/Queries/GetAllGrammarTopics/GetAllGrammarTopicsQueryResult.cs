using NorskApi.Application.GrammarTopics.Models;

namespace NorskApi.Application.GrammarTopics.Queries.GetAllGrammarTopics;

public record GetAllGrammarTopicQueryResult(List<GrammarTopicResult> GrammarTopics);
