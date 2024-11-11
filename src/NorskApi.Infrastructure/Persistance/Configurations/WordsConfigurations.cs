using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.WordAggregate;
using NorskApi.Domain.WordAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class WordsConfigurations : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        this.ConfigureWordTable(builder);
    }

    private void ConfigureWordTable(EntityTypeBuilder<Word> builder)
    {
        builder.ToTable("Words");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => WordId.Create(value));

        builder
            .Property(x => x.EssayId)
            .IsRequired()
            .HasConversion(x => x!.Value, value => EssayId.Create(value));

        builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Meaning).IsRequired(false).HasMaxLength(255);
        builder.Property(x => x.EnTranslation).IsRequired(false).HasMaxLength(255);
        builder.Property(x => x.NativeMeaning).IsRequired(false).HasMaxLength(255);
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.PartOfSpeechTag).IsRequired();
        builder.Property(x => x.DifficultyLevel).IsRequired();
        builder.Property(x => x.IsCompleted).IsRequired();

        builder
            .Property(x => x.SynonymIds)
            .IsRequired(false)
            .HasConversion(
                x =>
                    JsonSerializer.Serialize(
                        x,
                        new JsonSerializerOptions { WriteIndented = false }
                    ),
                value =>
                    JsonSerializer.Deserialize<List<WordId>>(value, new JsonSerializerOptions())
            )
            .Metadata.SetValueComparer(
                new ValueComparer<List<WordId>>(
                    (c1, c2) => c1 != null && c2 != null && c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => a ^ v.GetHashCode()),
                    c => c.ToList()
                )
            );

        builder
            .Property(x => x.AntonymIds)
            .IsRequired(false)
            .HasConversion(
                x =>
                    JsonSerializer.Serialize(
                        x,
                        new JsonSerializerOptions { WriteIndented = false }
                    ),
                value =>
                    JsonSerializer.Deserialize<List<WordId>>(value, new JsonSerializerOptions())
            )
            .Metadata.SetValueComparer(
                new ValueComparer<List<WordId>>(
                    (c1, c2) => c1 != null && c2 != null && c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => a ^ v.GetHashCode()),
                    c => c.ToList()
                )
            );

        builder.OwnsOne(
            word => word.WordGrammer,
            wordGrammerbuilder =>
            {
                wordGrammerbuilder.ToTable("WordGrammer");
                wordGrammerbuilder.HasKey(x => x.Id);
                wordGrammerbuilder
                    .Property(x => x.Id)
                    .ValueGeneratedNever()
                    .HasConversion(x => x.Value, value => WordGrammarId.Create(value));

                wordGrammerbuilder
                    .Property(x => x.WordId_FK)
                    .HasConversion(x => x!.Value, value => WordId.Create(value));

                wordGrammerbuilder
                    .Property(x => x.GenderMasculine)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.GenderFeminine)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.GenderNeutral)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.SingularDefinitiv)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.SingularIndefinitiv)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.PluralDefinitiv)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.PluralIndefinitiv)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder.Property(x => x.Infinitiv).IsRequired(false).HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.PresentTense)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder.Property(x => x.PastTense).IsRequired(false).HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.PresentPerfectTense)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder.Property(x => x.FutureTense).IsRequired(false).HasMaxLength(255);
                wordGrammerbuilder.Property(x => x.Positive).IsRequired(false).HasMaxLength(255);
                wordGrammerbuilder.Property(x => x.Comparative).IsRequired(false).HasMaxLength(255);
                wordGrammerbuilder.Property(x => x.Superlative).IsRequired(false).HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.SuperlativeDetermined)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.PastParticiple)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder
                    .Property(x => x.PresentParticiple)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordGrammerbuilder.Property(x => x.Irregular).IsRequired(false);
                wordGrammerbuilder.Property(x => x.StrongVerb).IsRequired(false);
                wordGrammerbuilder.Property(x => x.WeakVerb).IsRequired(false);
            }
        );
        builder.OwnsOne(
            word => word.WordUsageExample,
            wordUsageExamplebuilder =>
            {
                wordUsageExamplebuilder.ToTable("WordUsageExample");
                wordUsageExamplebuilder.HasKey(x => x.Id);
                wordUsageExamplebuilder
                    .Property(x => x.Id)
                    .ValueGeneratedNever()
                    .HasConversion(x => x.Value, value => WordUsageExampleId.Create(value));

                wordUsageExamplebuilder
                    .Property(x => x.WordId_FK)
                    .HasConversion(x => x!.Value, value => WordId.Create(value));

                wordUsageExamplebuilder
                    .Property(x => x.CorrectSentence)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordUsageExamplebuilder
                    .Property(x => x.IncorrectSentence)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordUsageExamplebuilder
                    .Property(x => x.EnglishSentence)
                    .IsRequired(false)
                    .HasMaxLength(255);
                wordUsageExamplebuilder
                    .Property(x => x.NewSentence)
                    .IsRequired(false)
                    .HasMaxLength(255);
            }
        );
    }
}
