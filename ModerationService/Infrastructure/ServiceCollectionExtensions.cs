using Infrastructure.Data;
using Infrastructure.Data.Db;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UseCases.CreateReport;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddModerationInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException("Connection string 'Default' not found.");
        
        services.AddDbContext<ModerationServiceDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IReportRepository, ReportRepository>();
        
        services.AddHostedService<MigrationRunner>();
        
        return services;
    }   
}