using Microsoft.EntityFrameworkCore;
using ShenzhenLhgs.Models;

namespace ShenzhenLhgs.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<GzfRanking> GzfRankings { get; set; }
    public DbSet<AjfRanking> AjfRankings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GzfRanking>(b =>
        {
            b.HasKey(t => t.Shoulhzh);
            b.HasIndex(t => t.Xingm);
            b.HasIndex(t => t.Sfzh);
        });
        modelBuilder.Entity<AjfRanking>(b =>
        {
            b.HasKey(t => t.Shoulhzh);
            b.HasIndex(t => t.Xingm);
            b.HasIndex(t => t.Sfzh);
        });
    }
}