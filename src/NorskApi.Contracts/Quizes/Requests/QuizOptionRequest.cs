namespace NorskApi.Contracts.Quizes.Requests;

public record QuizOptionRequest(string Title, bool IsCorrect, bool? MultipleChoiceAnswer);
