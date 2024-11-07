namespace NorskApi.Contracts.Quizes.Requests;

public record UpdateQuizOptionRequest(
    Guid Id,
    string Title,
    bool IsCorrect,
    bool? MultipleChoiceAnswer
);
