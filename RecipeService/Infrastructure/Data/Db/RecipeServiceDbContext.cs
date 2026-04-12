using Infrastructure.Data.Dtos;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data.Db;

public sealed class RecipeServiceDbContext(DbContextOptions<RecipeServiceDbContext>  options) : DbContext(options)
{
    public DbSet<RecipeDto> Recipes => Set<RecipeDto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecipeDto>(builder =>
        {
            builder.ToTable("Recipes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Calories).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Ingredients).IsRequired();
            builder.Property(x => x.Instructions).IsRequired();
            builder.Property(x => x.DateCreated).IsRequired();
            
            builder.HasIndex(x => x.Id);
        });
    }
}