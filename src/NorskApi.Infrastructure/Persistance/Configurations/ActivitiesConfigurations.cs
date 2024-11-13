using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorskApi.Domain.ActivityAggregate;
using NorskApi.Domain.ActivityAggregate.ValueObjects;

namespace NorskApi.Infrastructure.Persistance.Configurations;

public class ActivitesConfigurations : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        this.ConfigureActivityTable(builder);
    }

    private void ConfigureActivityTable(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable("Activites");

        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(x => x.Value, value => ActivityId.Create(value));

        builder.Property(x => x.Label).IsRequired().HasMaxLength(100);

        builder.HasIndex(x => x.Label).IsUnique();

        builder.Property(x => x.ActivityType).IsRequired().HasConversion<string>();

        builder.Property(x => x.CreatedDateTime).IsRequired();

        builder.Property(x => x.UpdatedDateTime).IsRequired();
    }
}
