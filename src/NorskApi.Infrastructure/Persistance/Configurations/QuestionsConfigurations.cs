using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.QuestionAggregate;
using NorskApi.Domain.QuestionAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class QuestionsConfigurations : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        this.ConfigureQuestionTable(builder);
    }

    private void ConfigureQuestionTable(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("Questions");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => QuestionId.Create(value));

        builder
            .Property(x => x.EssayId)
            .IsRequired(true)
            .HasConversion(x => x!.Value, value => EssayId.Create(value));

        builder.Property(x => x.Label).IsRequired().HasMaxLength(255);

        builder.Property(x => x.Answer).IsRequired().HasMaxLength(500);

        builder.Property(x => x.IsCompleted).IsRequired();

        builder.Property(x => x.DifficultyLevel).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }
}
