using Microsoft.EntityFrameworkCore;
using Musikbibliotek.Models;

namespace Musikbibliotek.Data;

public class MusicContext : DbContext
{
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Album> Albums => Set<Album>();
    public DbSet<Track> Tracks => Set<Track>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=musiclibrary.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>()
            .HasIndex(a => a.Name)
            .IsUnique();

        modelBuilder.Entity<Artist>()
            .Property(a => a.Name)
            .IsRequired();

        modelBuilder.Entity<Album>()
            .Property(a => a.Title)
            .IsRequired();

        modelBuilder.Entity<Track>()
            .Property(t => t.Title)
            .IsRequired();

        modelBuilder.Entity<Track>()
            .Property(t => t.DurationSeconds)
            .IsRequired();
    }
}
