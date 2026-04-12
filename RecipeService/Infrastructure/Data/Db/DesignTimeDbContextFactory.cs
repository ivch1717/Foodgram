using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Db;

internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RecipeServiceDbContext>
{
    public RecipeServiceDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
        
        var connectionString =
            configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException(
                "Connection string 'Default' not found.");
        
        var options = new DbContextOptionsBuilder<RecipeServiceDbContext> ()
            .UseNpgsql(connectionString)
            .Options;
        
        return new RecipeServiceDbContext(options);
    }
}