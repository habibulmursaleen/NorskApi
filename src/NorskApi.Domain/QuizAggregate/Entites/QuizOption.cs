using NorskApi.Domain.Common.Models;
using NorskApi.Domain.QuizAggregate.Events.DomainEvent.QuizOption;
using NorskApi.Domain.QuizAggregate.ValueObjects;

namespace NorskApi.Domain.QuizAggregate.Entites;

public sealed class QuizOption : AggregateRoot<QuizOptionId, Guid>
{
    public string Title { get; set; }
    public bool IsCorrect { get; set; }
    public bool? MultipleChoiceAnswer { get; set; } // User input
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private QuizOption() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private QuizOption(QuizOptionId id, string title, bool isCorrect, bool? multipleChoiceAnswer)
        : base(id)
    {
        this.Id = id;
        this.Title = title;
        this.IsCorrect = isCorrect;
        this.MultipleChoiceAnswer = multipleChoiceAnswer;
    }

    public static QuizOption Create(string title, bool isCorrect, bool? multipleChoiceAnswer)
    {
        QuizOption quizOption = new QuizOption(
            QuizOptionId.CreateUnique(),
            title,
            isCorrect,
            multipleChoiceAnswer
        );

        quizOption.AddDomainEvent(new QuizOptionCreatedDomainEvent(quizOption));

        return quizOption;
    }

    public void Update(string title, bool isCorrect, bool? multipleChoiceAnswer)
    {
        this.Title = title;
        this.IsCorrect = isCorrect;
        this.MultipleChoiceAnswer = multipleChoiceAnswer;

        this.AddDomainEvent(new QuizOptionUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new QuizOptionDeletedDomainEvent(this));
    }
}
