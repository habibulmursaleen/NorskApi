using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.DiscussionAggregate;
using NorskApi.Domain.DiscussionAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class DiscussionsConfigurations : IEntityTypeConfiguration<Discussion>
{
    public void Configure(EntityTypeBuilder<Discussion> builder)
    {
        this.ConfigureDiscussionTable(builder);
    }

    private void ConfigureDiscussionTable(EntityTypeBuilder<Discussion> builder)
    {
        builder.ToTable("Discussions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                x => x.Value,
                value => DiscussionId.Create(value)
            );

        builder.Property(x => x.EssayId)
            .IsRequired(false)
            .HasConversion(
                x => x!.Value,
                value => EssayId.Create(value)
            );

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.DiscussionEssays)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Note)
            .IsRequired()
            .HasMaxLength(500);


        builder.Property(x => x.DifficultyLevel)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.IsCompleted)
            .IsRequired();

        builder.Property(x => x.CreatedDateTime)
            .IsRequired();

        builder.Property(x => x.UpdatedDateTime)
            .IsRequired();

    }
}