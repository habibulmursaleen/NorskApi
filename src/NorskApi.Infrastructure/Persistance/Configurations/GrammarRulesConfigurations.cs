using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.GrammmarRuleAggregate;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class GrammarRulesConfigurations : IEntityTypeConfiguration<GrammarRule>
{
    public void Configure(EntityTypeBuilder<GrammarRule> builder)
    {
        this.ConfigureGrammarRuleTable(builder);
    }

    private void ConfigureGrammarRuleTable(EntityTypeBuilder<GrammarRule> builder)
    {
        builder.ToTable("GrammarRules");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => GrammarRuleId.Create(value));

        builder
            .Property(x => x.TopicId)
            .IsRequired()
            .HasConversion(x => x.Value, value => TopicId.Create(value));

        builder.Property(x => x.Label).IsRequired().HasMaxLength(255);

        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(255);

        builder.Property(x => x.ExplanatoryNotes).IsRequired(false).HasMaxLength(255);

        builder.Property(x => x.SentenceStructure).IsRequired();

        builder.Property(x => x.RuleType).IsRequired(false).HasMaxLength(255);

        builder.Property(x => x.DifficultyLevel).IsRequired();

        builder.Property(x => x.Tags).IsRequired();

        builder.Property(x => x.AdditionalInformation).IsRequired(false).HasMaxLength(255);

        builder.Property(x => x.Comments).IsRequired();

        builder
            .Property(x => x.RelatedRuleIds)
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

        builder.OwnsMany(
            grammarRule => grammarRule.Exceptions,
            exceptionsbuilder =>
            {
                exceptionsbuilder.ToTable("Exceptions");
                exceptionsbuilder.HasKey(x => x.Id);
                exceptionsbuilder
                    .Property(x => x.Id)
                    .ValueGeneratedNever()
                    .HasConversion(x => x.Value, value => ExceptionId.Create(value));

                exceptionsbuilder
                    .Property(x => x.GrammarRuleId_FK)
                    .IsRequired()
                    .HasConversion(x => x!.Value, value => GrammarRuleId.Create(value));

                exceptionsbuilder.Property(x => x.Title).IsRequired(false).HasMaxLength(255);
                exceptionsbuilder.Property(x => x.Description).IsRequired(false).HasMaxLength(255);
                exceptionsbuilder.Property(x => x.Comments).IsRequired(false).HasMaxLength(255);
                exceptionsbuilder
                    .Property(x => x.CorrectSentence)
                    .IsRequired(false)
                    .HasMaxLength(255);
                exceptionsbuilder
                    .Property(x => x.IncorrectSentence)
                    .IsRequired(false)
                    .HasMaxLength(255);
            }
        );

        builder.OwnsMany(
            grammarRule => grammarRule.ExampleOfRules,
            exampleOfRulesbuilder =>
            {
                exampleOfRulesbuilder.ToTable("ExampleOfRules");
                exampleOfRulesbuilder.HasKey(x => x.Id);
                exampleOfRulesbuilder
                    .Property(x => x.Id)
                    .ValueGeneratedNever()
                    .HasConversion(x => x.Value, value => ExampleOfRuleId.Create(value));

                exampleOfRulesbuilder
                    .Property(x => x.GrammarRuleId_FK)
                    .IsRequired()
                    .HasConversion(x => x!.Value, value => GrammarRuleId.Create(value));

                exampleOfRulesbuilder
                    .Property(x => x.Subjunction)
                    .IsRequired(false)
                    .HasMaxLength(255);
                exampleOfRulesbuilder.Property(x => x.Subject).IsRequired(false).HasMaxLength(255);
                exampleOfRulesbuilder
                    .Property(x => x.Adverbial)
                    .IsRequired(false)
                    .HasMaxLength(255);
                exampleOfRulesbuilder.Property(x => x.Verb).IsRequired(false).HasMaxLength(255);
                exampleOfRulesbuilder.Property(x => x.Object).IsRequired(false).HasMaxLength(255);
                exampleOfRulesbuilder.Property(x => x.Rest).IsRequired(false).HasMaxLength(255);
                exampleOfRulesbuilder
                    .Property(x => x.CorrectSentence)
                    .IsRequired(false)
                    .HasMaxLength(255);
                exampleOfRulesbuilder
                    .Property(x => x.EnglishSentence)
                    .IsRequired(false)
                    .HasMaxLength(255);
                exampleOfRulesbuilder
                    .Property(x => x.IncorrectSentence)
                    .IsRequired(false)
                    .HasMaxLength(255);
                exampleOfRulesbuilder
                    .Property(x => x.TransformationFrom)
                    .IsRequired(false)
                    .HasMaxLength(255);
                exampleOfRulesbuilder
                    .Property(x => x.TransformationTo)
                    .IsRequired(false)
                    .HasMaxLength(255);
            }
        );
    }
}
