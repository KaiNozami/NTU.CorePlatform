using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NTU.CorePlatform.Infrastructure.Persistence.DbContext;

namespace NTU.CorePlatform.Infrastructure.Persistence.DbContext;

/// <summary>
/// Design-time factory for EF Core migrations
/// </summary>
public sealed class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();

        // Tìm appsettings.json ở thư mục hiện tại hoặc thư mục project API
        var apiPath = Path.Combine(basePath, "..", "NTU.CorePlatform.API");
        if (!File.Exists(Path.Combine(basePath, "appsettings.json")) && Directory.Exists(apiPath))
        {
            basePath = Path.GetFullPath(apiPath);
        }

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

