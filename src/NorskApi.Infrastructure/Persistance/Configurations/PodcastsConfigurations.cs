using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.PodcastAggregate;
using NorskApi.Domain.PodcastAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class PodcastsConfigurations : IEntityTypeConfiguration<Podcast>
{
    public void Configure(EntityTypeBuilder<Podcast> builder)
    {
        this.ConfigurePodcastTable(builder);
    }

    private void ConfigurePodcastTable(EntityTypeBuilder<Podcast> builder)
    {
        builder.ToTable("Podcasts");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => PodcastId.Create(value));

        builder
            .Property(x => x.EssayId)
            .IsRequired(false)
            .HasConversion(x => x!.Value, value => EssayId.Create(value));

        builder.Property(x => x.Label).IsRequired().HasMaxLength(255);

        builder.Property(x => x.Descriptions).IsRequired().HasMaxLength(500);

        builder.Property(x => x.Logo).IsRequired().HasMaxLength(255);

        builder.Property(x => x.Url).IsRequired().HasMaxLength(255);

        builder.Property(x => x.IsCompleted).IsRequired();

        builder.Property(x => x.IsFeatured).IsRequired();

        builder.Property(x => x.DifficultyLevel).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }
}
