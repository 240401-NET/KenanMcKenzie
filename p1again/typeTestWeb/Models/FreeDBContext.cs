using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace typeTestWeb.Models;

public partial class FreeDBContext : DbContext
{
    public FreeDBContext()
    {
    }

    public FreeDBContext(DbContextOptions<FreeDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Leaderboard> Leaderboards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:kwm349.database.windows.net,1433;Initial Catalog=FreeDB;Persist Security Info=False;User ID=revpro-kwm;Password=CooperOtis1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__app_user__1788CCACFF825560");

            entity.ToTable("app_user", "Type_Test");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Username).HasMaxLength(20);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__games__2AB897DD8238538F");

            entity.ToTable("games", "Type_Test");

            entity.Property(e => e.GameId)
                .ValueGeneratedNever()
                .HasColumnName("GameID");
            entity.Property(e => e.Awpm).HasColumnName("AWPM");
            entity.Property(e => e.GameDate).HasColumnType("datetime");
            entity.Property(e => e.GameText).HasMaxLength(255);
            entity.Property(e => e.TimeTaken).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Wpm).HasColumnName("WPM");

            entity.HasOne(d => d.User).WithMany(p => p.Games)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__games__UserID__04E4BC85");
        });

        modelBuilder.Entity<Leaderboard>(entity =>
        {
            entity.HasKey(e => e.LeaderboardId).HasName("PK__Leaderbo__B358A1E6D24F9AAF");

            entity.ToTable("Leaderboard", "Type_Test");

            entity.Property(e => e.LeaderboardId)
                .ValueGeneratedNever()
                .HasColumnName("LeaderboardID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Leaderboards)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Leaderboa__UserI__0A9D95DB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
