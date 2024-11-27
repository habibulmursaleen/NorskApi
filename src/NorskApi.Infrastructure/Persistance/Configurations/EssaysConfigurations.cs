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
        this.ConfigureEssayActivityIdsTable(builder);
        this.ConfigureEssayTagIdsTable(builder);
        this.ConfigureEssayRelatedGrammarTopicIdsTable(builder);
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

        builder.Property(x => x.Status).IsRequired().HasConversion<string>();

        builder.Property(x => x.Notes).IsRequired().HasMaxLength(255);

        builder.Property(x => x.IsCompleted).IsRequired();

        builder.Property(x => x.IsSaved).IsRequired();

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

        builder.OwnsMany(
            essay => essay.Roleplays,
            roleplayssbuilder =>
            {
                roleplayssbuilder.ToTable("Roleplays");
                roleplayssbuilder.HasKey(x => x.Id);
                roleplayssbuilder
                    .Property(x => x.Id)
                    .ValueGeneratedNever()
                    .HasConversion(x => x.Value, value => RoleplayId.Create(value));
                roleplayssbuilder.Property(x => x.Content).IsRequired().HasMaxLength(255);
                roleplayssbuilder.Property(x => x.IsCompleted).IsRequired();
            }
        );
    }

    private void ConfigureEssayActivityIdsTable(EntityTypeBuilder<Essay> builder)
    {
        builder.OwnsMany(
            m => m.EssayActivityIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("EssayActivityIds");

                reviewBuilder.WithOwner().HasForeignKey("EssayId");

                reviewBuilder.HasKey("Id");

                reviewBuilder
                    .Property(r => r.Value)
                    .HasColumnName("ActivityId")
                    .ValueGeneratedNever();
            }
        );

        // when the lists of ids are nested into the parent entity, we need to set the property access mode to field
        // customBuilder.OwnsMany(
        //             x => x.EssayActivityIds,
        //             quickKeyBuilder =>
        //             {
        //                 quickKeyBuilder.ToTable("EssayActivityIds");

        //                 quickKeyBuilder
        //                     .Property<Guid>("Id")
        //                     .HasColumnName("Id")
        //                     .ValueGeneratedOnAdd();
        //                 quickKeyBuilder.HasKey("Id");

        //                 quickKeyBuilder.WithOwner().HasForeignKey("EssayId"); //immediate parent entity

        //                 quickKeyBuilder
        //                     .Property(x => x.Value)
        //                     .HasColumnName("ActivityId")
        //                     .IsRequired()
        //                     .ValueGeneratedNever();
        //             }
        //         );

        //         customBuilder
        //             .Navigation(x => x.EssayActivityIds)
        //             .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder
            .Metadata.FindNavigation(nameof(Essay.EssayActivityIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureEssayTagIdsTable(EntityTypeBuilder<Essay> builder)
    {
        builder.OwnsMany(
            m => m.EssayTagIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("EssayTagIds");

                reviewBuilder.WithOwner().HasForeignKey("EssayId");

                reviewBuilder.HasKey("Id");

                reviewBuilder.Property(r => r.Value).HasColumnName("TagId").ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Essay.EssayTagIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureEssayRelatedGrammarTopicIdsTable(EntityTypeBuilder<Essay> builder)
    {
        builder.OwnsMany(
            m => m.EssayRelatedGrammarTopicIds,
            reviewBuilder =>
            {
                reviewBuilder.ToTable("EssayRelatedGrammarTopicIds");

                reviewBuilder.WithOwner().HasForeignKey("EssayId");

                reviewBuilder.HasKey("Id");

                reviewBuilder.Property(r => r.Value).HasColumnName("TopicId").ValueGeneratedNever();
            }
        );

        builder
            .Metadata.FindNavigation(nameof(Essay.EssayRelatedGrammarTopicIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
