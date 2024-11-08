using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.EssayAggregate.ValueObjects;

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
            .IsRequired(false)
            .HasConversion(
                x =>
                    JsonSerializer.Serialize(
                        x,
                        new JsonSerializerOptions { WriteIndented = false }
                    ), // Serialize List<Guid>
                value => JsonSerializer.Deserialize<List<Guid>>(value, new JsonSerializerOptions()) // Deserialize as List<Guid>
            )
            .Metadata.SetValueComparer(
                new ValueComparer<List<Guid>>(
                    (c1, c2) => c1 != null && c2 != null && c1.SequenceEqual(c2), // Compare elements in the collection
                    c => c.Aggregate(0, (a, v) => a ^ v.GetHashCode()), // Generate a hash code for the collection
                    c => c.ToList()
                ) // Create a new list instance when copying
            );
    }
}
