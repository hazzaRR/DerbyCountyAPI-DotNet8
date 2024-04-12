using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DerbyCountyAPI.Models;

public partial class DerbycountyContext : DbContext
{
    public DerbycountyContext()
    {
    }

    public DerbycountyContext(DbContextOptions<DerbycountyContext> options)
        : base(options)
    {
    }


    public virtual DbSet<LeagueTable> LeagueTables { get; set; }

    public virtual DbSet<MatchResult> MatchResults { get; set; }

    public virtual DbSet<UpcomingFixture> UpcomingFixtures { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeagueTable>(entity =>
        {
            entity.HasKey(e => e.Team).HasName("league_table_pkey");

            entity.ToTable("league_table");

            entity.HasIndex(e => e.LeaguePosition, "league_table_league_position_key").IsUnique();

            entity.Property(e => e.Team)
                .HasMaxLength(255)
                .HasColumnName("team");
            entity.Property(e => e.Draws).HasColumnName("draws");
            entity.Property(e => e.GamesPlayed).HasColumnName("games_played");
            entity.Property(e => e.GoalDifference).HasColumnName("goal_difference");
            entity.Property(e => e.GoalsAgainst).HasColumnName("goals_against");
            entity.Property(e => e.GoalsFor).HasColumnName("goals_for");
            entity.Property(e => e.LeaguePosition).HasColumnName("league_position");
            entity.Property(e => e.Losses).HasColumnName("losses");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.Wins).HasColumnName("wins");
        });

        modelBuilder.Entity<MatchResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("match_results_pkey");

            entity.ToTable("match_results");

            entity.HasIndex(e => new { e.HomeTeam, e.AwayTeam, e.Kickoff, e.Competition }, "uniquematchresult").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AwayScore).HasColumnName("away_score");
            entity.Property(e => e.AwayTeam)
                .HasMaxLength(255)
                .HasColumnName("away_team");
            entity.Property(e => e.Competition)
                .HasMaxLength(255)
                .HasColumnName("competition");
            entity.Property(e => e.HomeScore).HasColumnName("home_score");
            entity.Property(e => e.HomeTeam)
                .HasMaxLength(255)
                .HasColumnName("home_team");
            entity.Property(e => e.Kickoff)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("kickoff");
            entity.Property(e => e.PenaltiesScore)
                .HasMaxLength(255)
                .HasColumnName("penalties_score");
            entity.Property(e => e.Result)
                .HasMaxLength(255)
                .HasColumnName("result");
            entity.Property(e => e.Season)
                .HasMaxLength(255)
                .HasColumnName("season");
            entity.Property(e => e.Stadium)
                .HasMaxLength(255)
                .HasColumnName("stadium");
        });

        modelBuilder.Entity<UpcomingFixture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("upcoming_fixtures_pkey");

            entity.ToTable("upcoming_fixtures");

            entity.HasIndex(e => new { e.HomeTeam, e.AwayTeam, e.Kickoff, e.Competition }, "uniquefixture").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AwayTeam)
                .HasMaxLength(255)
                .HasColumnName("away_team");
            entity.Property(e => e.Competition)
                .HasMaxLength(255)
                .HasColumnName("competition");
            entity.Property(e => e.HomeTeam)
                .HasMaxLength(255)
                .HasColumnName("home_team");
            entity.Property(e => e.Kickoff)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("kickoff");
            entity.Property(e => e.SkySportsUrl)
                .HasMaxLength(255)
                .HasColumnName("sky_sports_url");
            entity.Property(e => e.Stadium)
                .HasMaxLength(255)
                .HasColumnName("stadium");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
