using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.SubjunctionAggregate;
using NorskApi.Domain.SubjunctionAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class SubjunctionsConfigurations : IEntityTypeConfiguration<Subjunction>
{
    public void Configure(EntityTypeBuilder<Subjunction> builder)
    {
        this.ConfigureSubjunctionTable(builder);
    }

    private void ConfigureSubjunctionTable(EntityTypeBuilder<Subjunction> builder)
    {
        builder.ToTable("Subjunctions");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => SubjunctionId.Create(value));

        builder.Property(x => x.Label).IsRequired();

        builder.Property(x => x.SubjunctionType).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }
}
