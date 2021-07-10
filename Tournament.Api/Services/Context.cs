﻿using Microsoft.EntityFrameworkCore;
using Tournament.Model;

namespace Tournament.Api.Services
{
    public class Context : DbContext
    {
        public DbSet<Tournament.Model.Championship> Tournaments { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Championship>(entity =>
            {
                entity.HasKey(e => e.TournamentID);
                entity.HasMany(e => e.Games)
                    .WithOne(e => e.Championship)
                    .HasForeignKey(e => e.TournamentID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TournamentTeam>(entity =>
            {
                entity.HasKey(e => new { e.TournamentID, e.TeamID });

                entity.HasOne(e => e.Team)
                    .WithMany(e => e.TournamentTeams)
                    .HasForeignKey(e => e.TeamID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Championship)
                    .WithMany(e => e.TournamentTeams)
                    .HasForeignKey(e => e.TournamentID)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<GameTeam>(entity => { entity.HasKey(e => new { e.GameID, e.TeamID }); });
            
            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameID);

                entity.HasMany(e => e.Participants)
                    .WithOne(e => e.Game)
                    .HasForeignKey(e => e.GameID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Winner)
                    .WithMany(e => e.WonGames)
                    .HasForeignKey(e => e.GameID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamID);

                entity.HasMany(e => e.ParticiparedGames)
                    .WithOne(e => e.Team)
                    .HasForeignKey(e => e.TeamID)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}