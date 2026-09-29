using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection.Emit;
using NTU.CorePlatform.Domain.Common.Events;
using NTU.CorePlatform.Domain.Entities.Identity;
using NTU.CorePlatform.Domain.Entities.StudentManagement;

namespace NTU.CorePlatform.Infrastructure.Persistence.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // ============================
    // DbSets
    // ============================
    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();

    // ============================
    // Model configuration
    // ============================
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Bỏ qua DomainEvent khỏi EF Model
        modelBuilder.Ignore<DomainEvent>();

        // Áp dụng tự động các Configuration (UserConfiguration, StudentConfiguration...) trong assembly này
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Áp dụng Global Query Filter cho Soft Delete (IsDeleted = false)
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            ApplySoftDeleteFilter(modelBuilder, entityType);
        }
    }

    private static void ApplySoftDeleteFilter(ModelBuilder modelBuilder, IMutableEntityType entityType)
    {
        var prop = entityType.FindProperty("IsDeleted");
        if (prop == null) return;

        var parameter = Expression.Parameter(entityType.ClrType, "e");
        var body = Expression.Equal(
            Expression.Property(parameter, "IsDeleted"),
            Expression.Constant(false)
        );

        var lambda = Expression.Lambda(body, parameter);

        modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
    }
}