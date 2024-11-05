using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.RoleplayAggregate;
using NorskApi.Domain.RoleplayAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class RoleplaysConfigurations : IEntityTypeConfiguration<Roleplay>
{
    public void Configure(EntityTypeBuilder<Roleplay> builder)
    {
        this.ConfigureRoleplayTable(builder);
    }

    private void ConfigureRoleplayTable(EntityTypeBuilder<Roleplay> builder)
    {
        builder.ToTable("Roleplays");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => RoleplayId.Create(value));

        builder
            .Property(x => x.EssayId)
            .IsRequired(true)
            .HasConversion(x => x!.Value, value => EssayId.Create(value));

        builder.Property(x => x.Content).IsRequired().HasMaxLength(500);

        builder.Property(x => x.IsCompleted).IsRequired();

        builder.Property(x => x.DifficultyLevel).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }
}
