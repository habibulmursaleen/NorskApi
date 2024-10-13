using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.Entities.QuizAggregate.Events.DomainEvent;
using NorskApi.Domain.QuizAggregate.Entites;
using NorskApi.Domain.QuizAggregate.Events.DomainEvent.Quiz;
using NorskApi.Domain.QuizAggregate.ValueObjects;

namespace NorskApi.Domain.QuizAggregate;

public sealed class Quiz : AggregateRoot<QuizId, Guid>
{
    public Guid EssayId { get; set; }
    public string? Question { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } // Enum: A1, A2, B1, B2, C1
    public QuizType Type { get; set; } // Enum: MULTIPLE_CHOICE, BOOLEAN, STRING
    private readonly List<QuizOption> options = new();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public IReadOnlyCollection<QuizOption> QuizOption => this.QuizOption;

    private Quiz() { }

    private Quiz(
        QuizId id,
        Guid essayId,
        string question,
        DifficultyLevel difficultyLevel,
        QuizType type,
        List<QuizOption> options,
        DateTime createdAt,
        DateTime updatedAt
    ) : base(id)
    {
        this.Id = id;
        this.EssayId = essayId;
        this.Question = question;
        this.DifficultyLevel = difficultyLevel;
        this.Type = type;
        this.options = options;
        this.CreatedAt = createdAt;
        this.UpdatedAt = updatedAt;
    }

    public static Quiz Create(
        Guid essayId,
        string question,
        DifficultyLevel difficultyLevel,
        QuizType type,
        List<QuizOption> options
    )
    {
        Quiz quiz = new Quiz(
            QuizId.CreateUnique(),
            essayId,
            question,
            DifficultyLevel.A1,
            type,
            options,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

        quiz.AddDomainEvent(new QuizCreatedDomainEvent(quiz));

        return quiz;
    }

    public void Update(
        string question,
        DifficultyLevel difficultyLevel,
        QuizType type,
        List<QuizOption> options
    )
    {
        this.Question = question;
        this.DifficultyLevel = difficultyLevel;
        this.Type = type;
        this.UpdatedAt = DateTime.UtcNow;

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
            // Update existing options or add new ones
            foreach (var newOption in newOptions)
            {
                var existingOption = this.options.FirstOrDefault(o => o.Id == newOption.Id);
                if (existingOption is not null)
                {
                    // Update existing option
                    existingOption.Update(newOption.Title, newOption.IsCorrect, newOption.Answer);
                }
                else
                {
                    // Add new option
                    this.options.Add(newOption);
                }
            }

            // Remove options that are no longer in the new list
            this.options.RemoveAll(o => newOptions.All(no => no.Id != o.Id));
        }
    }
}