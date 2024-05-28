using Microsoft.EntityFrameworkCore;
using SportStats.Models;

namespace SportStats.Data;

public class StatsContext:DbContext
{
    public StatsContext(DbContextOptions<StatsContext> options) : base(options) { }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<BaseStat> Stats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseStat>()
            .HasDiscriminator<string>("StatType")
            .HasValue<Shot>("Shot")
            .HasValue<Block>("Block")
        .HasValue<Interception>("Interception")
        .HasValue<Rebound>("Rebound")
        .HasValue<Pass>("Pass");

      

        base.OnModelCreating(modelBuilder);
    }
}
