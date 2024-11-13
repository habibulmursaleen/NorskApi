using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.NorskproveAggregate;
using NorskApi.Domain.NorskproveAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class NorskprovesConfigurations : IEntityTypeConfiguration<Norskprove>
{
    public void Configure(EntityTypeBuilder<Norskprove> builder)
    {
        this.ConfigureNorskproveTable(builder);
        this.ConfigureNorskproveTagIdsTable(builder);
        this.ConfigureSpeakingContentIdsTable(builder);
        this.ConfigureListeningContentIdsTable(builder);
        this.ConfigureReadingContentIdsTable(builder);
        this.ConfigureWritingContentIdsTable(builder);
        this.ConfigureAdditionalGrammarTaskIdsTable(builder);
    }

    private void ConfigureNorskproveTable(EntityTypeBuilder<Norskprove> builder)
    {
        builder.ToTable("Norskproves");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => NorskproveId.Create(value));

        builder.Property(x => x.Title).IsRequired().HasMaxLength(255);

        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

        builder.Property(x => x.IsCompleted).IsRequired();

        builder.Property(x => x.IsSaved).IsRequired();

        builder.Property(x => x.Progress).IsRequired();

        builder.Property(x => x.TimeLimit).IsRequired();

        builder.Property(x => x.EstimatedCompletionTime).IsRequired();

        builder.Property(x => x.Attempts).IsRequired();

        builder.Property(x => x.MaxScore).IsRequired();

        builder.Property(x => x.Status).IsRequired().HasConversion<string>();

        builder.Property(x => x.DifficultyLevel).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }

    private void ConfigureNorskproveTagIdsTable(EntityTypeBuilder<Norskprove> builder)
    {
        builder.OwnsMany(
            m => m.NorskproveTagIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("NorskproveTagIds");

                reviewBuilder.WithOwner().HasForeignKey("NorskproveId");

                reviewBuilder.HasKey("Id");

                reviewBuilder.Property(r => r.Value).HasColumnName("TagId").ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Norskprove.NorskproveTagIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureSpeakingContentIdsTable(EntityTypeBuilder<Norskprove> builder)
    {
        builder.OwnsMany(
            m => m.SpeakingContentIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("SpeakingContentIds");

                reviewBuilder.WithOwner().HasForeignKey("NorskproveId");

                reviewBuilder.HasKey("Id");

                reviewBuilder
                    .Property(r => r.Value)
                    .HasColumnName("QuestionId")
                    .ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Norskprove.NorskproveTagIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureListeningContentIdsTable(EntityTypeBuilder<Norskprove> builder)
    {
        builder.OwnsMany(
            m => m.ListeningContentIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("ListeningContentIds");

                reviewBuilder.WithOwner().HasForeignKey("NorskproveId");

                reviewBuilder.HasKey("Id");

                reviewBuilder
                    .Property(r => r.Value)
                    .HasColumnName("DictationId")
                    .ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Norskprove.ListeningContentIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureReadingContentIdsTable(EntityTypeBuilder<Norskprove> builder)
    {
        builder.OwnsMany(
            m => m.ReadingContentIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("ReadingContentIds");

                reviewBuilder.WithOwner().HasForeignKey("NorskproveId");

                reviewBuilder.HasKey("Id");

                reviewBuilder.Property(r => r.Value).HasColumnName("EssayId").ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Norskprove.ReadingContentIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureWritingContentIdsTable(EntityTypeBuilder<Norskprove> builder)
    {
        builder.OwnsMany(
            m => m.WritingContentIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("WritingContentIds");

                reviewBuilder.WithOwner().HasForeignKey("NorskproveId");

                reviewBuilder.HasKey("Id");

                reviewBuilder
                    .Property(r => r.Value)
                    .HasColumnName("DiscussionId")
                    .ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Norskprove.WritingContentIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureAdditionalGrammarTaskIdsTable(EntityTypeBuilder<Norskprove> builder)
    {
        builder.OwnsMany(
            m => m.AdditionalGrammarTaskIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("AdditionalGrammarTaskIds");

                reviewBuilder.WithOwner().HasForeignKey("NorskproveId");

                reviewBuilder.HasKey("Id");

                reviewBuilder
                    .Property(r => r.Value)
                    .HasColumnName("TaskWorkId")
                    .ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Norskprove.AdditionalGrammarTaskIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
