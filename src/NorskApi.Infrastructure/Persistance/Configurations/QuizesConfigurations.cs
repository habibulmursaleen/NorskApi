using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.QuizAggregate;
using NorskApi.Domain.QuizAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class QuizsConfigurations : IEntityTypeConfiguration<Quiz>
{
    public void Configure(EntityTypeBuilder<Quiz> builder)
    {
        this.ConfigureQuizTable(builder);
    }

    private void ConfigureQuizTable(EntityTypeBuilder<Quiz> builder)
    {
        builder.ToTable("Quizzes");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => QuizId.Create(value));

        builder
            .Property(x => x.EssayId)
            .IsRequired(false)
            .HasConversion(x => x!.Value, value => EssayId.Create(value));

        builder
            .Property(x => x.TopicId)
            .IsRequired(false)
            .HasConversion(x => x!.Value, value => TopicId.Create(value));

        builder.Property(x => x.Question).IsRequired().HasMaxLength(255);

        builder.Property(x => x.Answer).IsRequired().HasMaxLength(255);

        builder.Property(x => x.IsRightAnswer).IsRequired();

        builder.Property(x => x.DifficultyLevel).IsRequired().HasConversion<string>();

        builder.Property(x => x.QuizType).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();

        builder.OwnsMany(
            quiz => quiz.QuizOptions,
            optionsbuilder =>
            {
                optionsbuilder.ToTable("QuizOptions");
                optionsbuilder.HasKey(x => x.Id);
                optionsbuilder
                    .Property(x => x.Id)
                    .ValueGeneratedNever()
                    .HasConversion(x => x.Value, value => QuizOptionId.Create(value));
                optionsbuilder.Property(x => x.Title).IsRequired().HasMaxLength(255);
                optionsbuilder.Property(x => x.IsCorrect).IsRequired();
                optionsbuilder.Property(x => x.MultipleChoiceAnswer).IsRequired();
            }
        );
    }
}
