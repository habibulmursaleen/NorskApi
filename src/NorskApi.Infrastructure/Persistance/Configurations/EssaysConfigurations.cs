using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class EssaysConfigurations : IEntityTypeConfiguration<Essay>
{
    public void Configure(EntityTypeBuilder<Essay> builder)
    {
        this.ConfigureEssayTable(builder);
    }

    private void ConfigureEssayTable(EntityTypeBuilder<Essay> builder)
    {
        builder.ToTable("Essays");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => EssayId.Create(value));

        builder.Property(x => x.Logo).IsRequired(false).HasMaxLength(255);

        builder.Property(x => x.Label).IsRequired().HasMaxLength(255);

        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(255);

        builder.Property(x => x.Progress).IsRequired();

        builder.Property(x => x.Activities).IsRequired(false);

        builder.Property(x => x.Status).IsRequired().HasConversion<string>();

        builder.Property(x => x.Notes).IsRequired().HasMaxLength(255);

        builder.Property(x => x.IsCompleted).IsRequired();

        builder.Property(x => x.IsSaved).IsRequired();

        builder.Property(x => x.Tags).IsRequired(false);

        builder.Property(x => x.DifficultyLevel).IsRequired().HasConversion<string>();

        builder.OwnsMany(
            essay => essay.Paragraphs,
            paragraphsbuilder =>
            {
                paragraphsbuilder.ToTable("Paragraphs");
                paragraphsbuilder.HasKey(x => x.Id);
                paragraphsbuilder
                    .Property(x => x.Id)
                    .ValueGeneratedNever()
                    .HasConversion(x => x.Value, value => ParagraphId.Create(value));
                paragraphsbuilder.Property(x => x.Title).IsRequired(false).HasMaxLength(255);
                paragraphsbuilder.Property(x => x.Content).IsRequired().HasMaxLength(255);
                paragraphsbuilder.Property(x => x.ContentType).IsRequired().HasConversion<string>();
            }
        );

        builder
            .Property(x => x.RelatedGrammarTopicIds)
            .HasConversion(
                v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                v => JsonSerializer.Deserialize<List<TopicId>>(v, new JsonSerializerOptions())
            )
            .Metadata.SetValueComparer(
                new ValueComparer<List<TopicId>>(
                    (c1, c2) => c1 != null && c2 != null && c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()
                )
            );
    }
}
