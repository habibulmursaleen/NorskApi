using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.LocalExpressionAggregate;
using NorskApi.Domain.LocalExpressionAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class LocalExpressionsConfigurations : IEntityTypeConfiguration<LocalExpression>
{
    public void Configure(EntityTypeBuilder<LocalExpression> builder)
    {
        this.ConfigureLocalExpressionTable(builder);
    }

    private void ConfigureLocalExpressionTable(EntityTypeBuilder<LocalExpression> builder)
    {
        builder.ToTable("LocalExpressions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                x => x.Value,
                value => LocalExpressionId.Create(value)
            );

        builder.Property(x => x.Label)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.MeaningInNorsk)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.MeaningInEnglish)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.LocalExpressionType)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.CreatedDateTime)
            .IsRequired();

        builder.Property(x => x.UpdatedDateTime)
            .IsRequired();
    }
}