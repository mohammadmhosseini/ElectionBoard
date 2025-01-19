using ElectionBoard.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectionBoard.Persistence;

public class ElectionDbContext(DbContextOptions<ElectionDbContext> options) : DbContext(options)
{
    public const string ConnectionStringName = "SvcElectionContext";

    public DbSet<State> States { get; set; }
    public DbSet<CondidateVote> CondidateVotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureCondidateVoteTable(modelBuilder);
        ConfigureStateTable(modelBuilder);
    }

    private static void ConfigureCondidateVoteTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CondidateVote>(builder =>
        {
            builder.HasKey(x => new { x.ElectionCycle, x.FipsCode, x.Code });

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Code)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.ElectionCycle)
                .IsRequired();

            builder.Property(x => x.FipsCode)
                .HasMaxLength(3)
                .IsRequired();
        });
    }

    private static void ConfigureStateTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CondidateVote>(builder =>
        {
            builder.HasKey(x => x.FipsCode);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.FipsCode)
                .HasMaxLength(3)
                .IsRequired();
        });
    }
}
