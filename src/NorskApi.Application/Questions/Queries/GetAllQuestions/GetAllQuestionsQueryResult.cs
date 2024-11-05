using NorskApi.Application.Questions.Models;

namespace NorskApi.Application.Questions.Queries.GetAllQuestions;

public record GetAllQuestionQueryResult(List<QuestionResult> Questions);
