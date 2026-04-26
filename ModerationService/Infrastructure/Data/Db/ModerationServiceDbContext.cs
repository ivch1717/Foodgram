using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Dtos;
namespace Infrastructure.Data.Db;

public sealed class ModerationServiceDbContext(DbContextOptions<ModerationServiceDbContext> options) : DbContext(options)
{
    public DbSet<ReportDto> Reports => Set<ReportDto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReportDto>(builder =>
        {
            builder.ToTable("Reports");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TargetId).IsRequired();
            builder.Property(x => x.TargetType).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Reason).IsRequired();
        });
    }
}