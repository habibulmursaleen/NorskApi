using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.GrammarTopicAggregate;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class GrammarTopicsConfigurations : IEntityTypeConfiguration<GrammarTopic>
{
    public void Configure(EntityTypeBuilder<GrammarTopic> builder)
    {
        this.ConfigureGrammarTopicTable(builder);
    }

    private void ConfigureGrammarTopicTable(EntityTypeBuilder<GrammarTopic> builder)
    {
        builder.ToTable("GrammarTopics");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => TopicId.Create(value));

        builder.Property(x => x.Label).IsRequired().HasMaxLength(255);

        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

        builder.Property(x => x.Status).IsRequired().HasConversion<string>();

        builder.Property(x => x.Chapter).IsRequired();

        builder.Property(x => x.ModuleCount).IsRequired();

        builder.Property(x => x.Progress).IsRequired();

        builder.Property(x => x.IsCompleted).IsRequired();

        builder.Property(x => x.IsSaved).IsRequired();

        builder.Property(x => x.Tags).IsRequired();

        builder.Property(x => x.DifficultyLevel).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }
}
