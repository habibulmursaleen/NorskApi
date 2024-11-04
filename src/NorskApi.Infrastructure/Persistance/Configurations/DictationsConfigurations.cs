using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.DictationAggregate;
using NorskApi.Domain.DictationAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class DictationsConfigurations : IEntityTypeConfiguration<Dictation>
{
    public void Configure(EntityTypeBuilder<Dictation> builder)
    {
        this.ConfigureDictationTable(builder);
    }

    private void ConfigureDictationTable(EntityTypeBuilder<Dictation> builder)
    {
        builder.ToTable("Dictations");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => DictationId.Create(value));

        builder
            .Property(x => x.EssayId)
            .IsRequired(false)
            .HasConversion(x => x!.Value, value => EssayId.Create(value));

        builder.Property(x => x.Label).IsRequired().HasMaxLength(255);

        builder.Property(x => x.Content).IsRequired().HasMaxLength(500);

        builder.Property(x => x.Answer).IsRequired().HasMaxLength(500);

        builder.Property(x => x.IsCompleted).IsRequired();

        builder.Property(x => x.DifficultyLevel).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }
}
