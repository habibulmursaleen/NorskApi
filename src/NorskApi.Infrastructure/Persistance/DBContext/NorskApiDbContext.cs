using NorskApi.Domain.LocalExpressionAggregate;
using Microsoft.EntityFrameworkCore;
using NorskApi.Infrastructure.Persistance.Interceptors;
using NorskApi.Domain.Common.Models;
using Microsoft.Extensions.Configuration;

namespace NorskApi.Infrastructure.Persistance.DBContext;

public sealed class NorskApiDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor publishDomainEventsInterceptor;
    private readonly string connectionString;
    public NorskApiDbContext(DbContextOptions<NorskApiDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor, IConfiguration configuration) : base(options)
    {
        this.publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        this.connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }

    public DbSet<LocalExpression> LocalExpressions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(NorskApiDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(connectionString, b => b.MigrationsAssembly("NorskApi.Api"))
                .AddInterceptors(publishDomainEventsInterceptor);
        }
    }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default(CancellationToken)
    )
    {
        this.SetTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimestamps()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e =>
                e.Entity is IHasTimeStamp
                && (e.State == EntityState.Added || e.State == EntityState.Modified)
            );

        foreach (var entityEntry in entries)
        {
            var entity = (IHasTimeStamp)entityEntry.Entity;

            if (entityEntry.State == EntityState.Added)
            {
                entity.CreatedDateTime = DateTime.UtcNow;
            }
            entity.UpdatedDateTime = DateTime.UtcNow;
        }
    }

}