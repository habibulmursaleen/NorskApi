using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.TaskWorkAggregate;
using NorskApi.Domain.TaskWorkAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class TaskWorksConfigurations : IEntityTypeConfiguration<TaskWork>
{
    public void Configure(EntityTypeBuilder<TaskWork> builder)
    {
        this.ConfigureTaskWorkTable(builder);
    }

    private void ConfigureTaskWorkTable(EntityTypeBuilder<TaskWork> builder)
    {
        builder.ToTable("TaskWorks");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => TaskWorkId.Create(value));

        builder
            .Property(x => x.TopicId)
            .IsRequired(true)
            .HasConversion(x => x!.Value, value => TopicId.Create(value));

        builder.Property(x => x.Logo).IsRequired();

        builder.Property(x => x.Label).IsRequired().HasMaxLength(500);

        builder.Property(x => x.TaskPointer).HasMaxLength(500);

        builder.Property(x => x.IsCompleted).IsRequired();

        builder.Property(x => x.Answer).HasMaxLength(500);

        builder.Property(x => x.Comments).HasMaxLength(500);

        builder.Property(x => x.AdditionalInfo).HasMaxLength(500);

        builder.Property(x => x.DifficultyLevel).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }
}
