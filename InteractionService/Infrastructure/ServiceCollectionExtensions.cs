using Infrastructure.Data;
using Infrastructure.Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data.Repositories;
using UseCases.CreateComment;
using UseCases.DelComment;
using UseCases.DelLike;
using UseCases.EditComment;
using UseCases.GetAmountCommentsByRecipeId;
using UseCases.GetAmountLikesByRecipeId;
using UseCases.GetCommentsByRecipeId;
using UseCases.GetCommentsByUserId;
using UseCases.GetLikesByUserId;
using UseCases.IsRecipeLiked;
using UseCases.PutLike;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException("Connection string 'Default' not found.");

        services.AddDbContext<InteractionServiceDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        services.AddScoped<ICreateCommentRepository, CreateCommentRepository>();
        services.AddScoped<IDelCommentRepository, DelCommentRepository>();
        services.AddScoped<IDelLikeRepository, DelLikeRepository>();
        services.AddScoped<IEditCommentRepository, EditCommentRepository>();
        services.AddScoped<IGetAmountCommentsByRecipeIdRepository, GetAmountCommentsByRecipeIdRepository>();
        services.AddScoped<IGetAmountLikesByRecipeIdRepository, GetAmountLikesByRecipeIdRepository>();
        services.AddScoped<IGetCommentsByRecipeIdRepository, GetCommentsByRecipeIdRepository>();
        services.AddScoped<IGetCommentsByUserIdRepository, GetCommentsByUserIdRepository>();
        services.AddScoped<IGetLikesByUserIdRepository, GetLikesByUserIdRepository>();
        services.AddScoped<IIsRecipeLikedRepository, IsRecipeLikedRepository>();
        services.AddScoped<IPutLikeRepository, PutLikeRepository>();
        
        services.AddHostedService<MigrationRunner>();
        
        return services;
    }
}