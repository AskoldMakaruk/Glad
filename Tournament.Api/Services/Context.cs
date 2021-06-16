using Microsoft.EntityFrameworkCore;
using Tournament.Model;

namespace Tournament.Api.Services
{
	public class Context : DbContext
	{
		public Context()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=database.db");

			//optionsBuilder.UseSqlServer("");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Model.Tournament>(entity =>
			{
				entity.HasKey(e => e.TournamentID);
				entity.HasMany(e => e.Games)
					.WithOne(e => e.Tournament)
					.HasForeignKey(e => e.TournamentID)
					.OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<TournamentTeam>(entity =>
			{
				entity.HasKey(e => new {e.TournamentID, e.TeamID});
				
				entity.HasOne(e => e.Team)
					.WithMany(e => e.TournamentTeams)
					.HasForeignKey(e => e.TeamID)
					.OnDelete(DeleteBehavior.Cascade);

				entity.HasOne(e => e.Tournament)
					.WithMany(e => e.TournamentTeams)
					.HasForeignKey(e => e.TournamentID)
					.OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<Game>(entity =>
			{
				entity.HasKey(e => e.GameID);

				entity.HasOne(e => e.Team1)
					.WithMany(e => e.Games)
					.HasForeignKey(e => e.GameID)
					.OnDelete(DeleteBehavior.Cascade);
				
				entity.HasOne(e => e.Team2)
					.WithMany(e => e.Games)
					.HasForeignKey(e => e.GameID)
					.OnDelete(DeleteBehavior.Cascade);
				
				entity.HasOne(e => e.Winner)
					.WithMany(e => e.Games)
					.HasForeignKey(e => e.GameID)
					.OnDelete(DeleteBehavior.Cascade);
			});
			
			modelBuilder.Entity<Team>(entity =>
			{
				entity.HasKey(e => e.TeamID);
			});
		}
	}
}