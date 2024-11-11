using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.SubjunctionAggregate.ValueObjects;
using NorskApi.Domain.SubjunctionAgreegate;

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

        builder.Property(x => x.Time).IsRequired();

        builder.Property(x => x.Arsak).IsRequired();

        builder.Property(x => x.Hensikt).IsRequired();

        builder.Property(x => x.Betingelse).IsRequired();

        builder.Property(x => x.Motsetning).IsRequired();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }
}
