using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.TagAggregate;
using NorskApi.Domain.TagAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class TagsConfigurations : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        this.ConfigureTagTable(builder);
    }

    private void ConfigureTagTable(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => TagId.Create(value));

        builder.Property(x => x.Label).IsRequired().HasMaxLength(100);

        builder.HasIndex(x => x.Label).IsUnique();

        builder.Property(x => x.Color).IsRequired().HasMaxLength(500);

        builder.Property(x => x.TagType).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }
}
