using System.Collections.Generic;

namespace Tournament.Model
{
	public class Users
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string PasswordHash { get; set; }
		public bool IsAdmin { get; set; }
	}

	public class Championship
	{
		public int TournamentID { get; set; }
		public string TournamentName { get; set; }
		public int TournamentPrizePool { get; set; }
		public string TournamentStatus { get; set; }
		public int RoundCount { get; set; }

		public ICollection<Game> Games { get; set; }
		public ICollection<TournamentTeam> TournamentTeams { get; set; }
	}

	public class TournamentTeam
	{
		public int TournamentID { get; set; }
		public int TeamID { get; set; }
		public int TeamNumber { get; set; }
		public int Place { get; set; }

		public Team Team { get; set; }
		public Championship Championship { get; set; }
	}

	public class Game
	{
		public int GameID { get; set; }
		public string GameName { get; set; }
		public int Round { get; set; }
		public int TournamentID { get; set; }

		public Championship Championship { get; set; }
		public ICollection<Team> Participants { get; set; }
		public Team Winner { get; set; }
	}

	public class Team
	{
		public int TeamID { get; set; }
		public string TeamName { get; set; }

		public ICollection<Game> ParticiparedGames { get; set; }
		public ICollection<Game> WonGames { get; set; }
		public ICollection<TournamentTeam> TournamentTeams { get; set; }
	}
}