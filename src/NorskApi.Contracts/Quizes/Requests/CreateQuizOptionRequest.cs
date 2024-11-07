namespace NorskApi.Contracts.Quizes.Requests;

public record CreateQuizOptionRequest(string Title, bool IsCorrect, bool? MultipleChoiceAnswer);
