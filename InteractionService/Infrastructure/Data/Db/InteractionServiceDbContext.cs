using Infrastructure.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Db;

public sealed class InteractionServiceDbContext(DbContextOptions<InteractionServiceDbContext>  options) : DbContext(options)
{
    public DbSet<LikeDto> Likes => Set<LikeDto>();
    public  DbSet<CommentDto> Comments => Set<CommentDto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LikeDto>(builder =>
        {
            builder.ToTable("Likes");
            builder.HasKey(x => new { x.UserId, x.RecipeId });
            
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.RecipeId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
        });

        modelBuilder.Entity<CommentDto>(builder =>
        {
            builder.ToTable("Comments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.RecipeId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Text).IsRequired();
        });
    }
    
    
}