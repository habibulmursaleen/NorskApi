using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.Entities.QuizAggregate.Events.DomainEvent;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.QuizAggregate.Entites;
using NorskApi.Domain.QuizAggregate.Enums;
using NorskApi.Domain.QuizAggregate.Events.DomainEvent.Quiz;
using NorskApi.Domain.QuizAggregate.ValueObjects;

namespace NorskApi.Domain.QuizAggregate;

public sealed class Quiz : AggregateRoot<QuizId, Guid>
{
    private readonly List<QuizOption> options = [];
    public EssayId? EssayId { get; set; }
    public TopicId? TopicId { get; set; }
    public string Question { get; set; }
    public string? Answer { get; set; }
    public bool IsRightAnswer { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public QuizType QuizType { get; set; } // Enum: MULTIPLE_CHOICE, BOOLEAN, TEXT
    public IReadOnlyCollection<QuizOption> QuizOptions => this.options;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Quiz() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Quiz(
        QuizId id,
        EssayId? essayId,
        TopicId? topicId,
        string question,
        string? answer,
        bool isRightAnswer,
        DifficultyLevel difficultyLevel,
        QuizType quizType,
        List<QuizOption> options
    )
        : base(id)
    {
        this.Id = id;
        this.EssayId = essayId;
        this.TopicId = topicId;
        this.Question = question;
        this.Answer = answer;
        this.IsRightAnswer = isRightAnswer;
        this.DifficultyLevel = difficultyLevel;
        this.QuizType = quizType;
        this.options = options;
    }

    public static Quiz Create(
        EssayId? essayId,
        TopicId? topicId,
        string question,
        string? answer,
        bool isRightAnswer,
        DifficultyLevel difficultyLevel,
        QuizType quizType,
        List<QuizOption> options
    )
    {
        Quiz quiz =
            new(
                QuizId.CreateUnique(),
                essayId,
                topicId,
                question,
                answer,
                isRightAnswer,
                difficultyLevel,
                quizType,
                options
            );

        quiz.AddDomainEvent(new QuizCreatedDomainEvent(quiz));

        return quiz;
    }

    public void Update(
        EssayId? essayId,
        TopicId? topicId,
        string question,
        string? answer,
        bool isRightAnswer,
        DifficultyLevel difficultyLevel,
        QuizType quizType,
        List<QuizOption> options
    )
    {
        this.EssayId = essayId;
        this.TopicId = topicId;
        this.Question = question;
        this.Answer = answer;
        this.IsRightAnswer = isRightAnswer;
        this.DifficultyLevel = difficultyLevel;
        this.QuizType = quizType;

        UpdateOptions(options);

        this.AddDomainEvent(new QuizUpdatedDomainEvent(this));
    }

    public void Delete()
    {
        this.AddDomainEvent(new QuizDeletedDomainEvent(this));
    }

    private void UpdateOptions(List<QuizOption> newOptions)
    {
        if (newOptions is not null)
        {
            foreach (var newOption in newOptions)
            {
                var existingOption = this.options.FirstOrDefault(o => o.Id == newOption.Id);

                if (existingOption is not null)
                {
                    existingOption.Update(
                        newOption.Title,
                        newOption.IsCorrect,
                        newOption.MultipleChoiceAnswer
                    );
                }
                else
                {
                    this.options.Add(newOption);
                }
            }

            this.options.RemoveAll(o => newOptions.All(no => no.Id != o.Id));
        }
    }
}
