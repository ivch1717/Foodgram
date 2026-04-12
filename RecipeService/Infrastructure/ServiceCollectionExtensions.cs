using Infrastructure.Data;
using Infrastructure.Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UseCases.Create;
using Infrastructure.Data.Repositories;
using UseCases.Delete;
using UseCases.Edit;
using UseCases.GetRecipeById;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException("Connection string 'Default' not found.");
        
        services.AddDbContext<RecipeServiceDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ICreateRecipeRepository, CreateRecipeRepository>();
        services.AddScoped<IDeleteRecipeRepository, DeleteRecipeRepository>();
        services.AddScoped<IEditRecipeRepository, EditRecipeRepository>();
        services.AddScoped<IGetRecipeByIdRepository, GetRecipeByIdRepository>();
        services.AddScoped<IGetRecipeByIdRepository, GetRecipeByIdRepository>();
        
        services.AddHostedService<MigrationRunner>();
        
        return services;
    }
}