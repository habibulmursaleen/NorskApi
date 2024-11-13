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
        this.ConfigureGrammarRuleTagIdsTable(builder);
        this.ConfigureRelatedGrammarRuleIdsTable(builder);
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

        builder.Property(x => x.RuleType).IsRequired(false).HasMaxLength(255);

        builder.Property(x => x.DifficultyLevel).IsRequired();

        builder.Property(x => x.AdditionalInformation).IsRequired(false).HasMaxLength(255);

        builder.Property(x => x.Comments).IsRequired();

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
            grammarRule => grammarRule.SentenceStructures,
            sentenceStructurebuilder =>
            {
                sentenceStructurebuilder.ToTable("SentenceStructure");
                sentenceStructurebuilder.HasKey(x => x.Id);
                sentenceStructurebuilder
                    .Property(x => x.Id)
                    .ValueGeneratedNever()
                    .HasConversion(x => x.Value, value => SentenceStructureId.Create(value));

                sentenceStructurebuilder.Property(x => x.Label).IsRequired(false).HasMaxLength(255);
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

    private void ConfigureGrammarRuleTagIdsTable(EntityTypeBuilder<GrammarRule> builder)
    {
        builder.OwnsMany(
            m => m.GrammarRuleTagIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("GrammarRuleTagIds");

                reviewBuilder.WithOwner().HasForeignKey("GrammarRuleId");

                reviewBuilder.HasKey("Id");

                reviewBuilder.Property(r => r.Value).HasColumnName("TagId").ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(GrammarRule.GrammarRuleTagIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureRelatedGrammarRuleIdsTable(EntityTypeBuilder<GrammarRule> builder)
    {
        builder.OwnsMany(
            m => m.RelatedGrammarRuleIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("RelatedGrammarRuleIds");

                reviewBuilder.WithOwner().HasForeignKey("GrammarRuleId");

                reviewBuilder.HasKey("Id");

                reviewBuilder.Property(r => r.Value).HasColumnName("TagId").ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(GrammarRule.RelatedGrammarRuleIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
