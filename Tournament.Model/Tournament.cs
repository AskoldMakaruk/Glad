using System.Collections.Generic;

namespace Tournament.Model
{
	public class Tournament
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
		public Tournament Tournament { get; set; }
	}

	public class Game
	{
		public int GameID { get; set; }
		public string GameName { get; set; }
		public int Round { get; set; }
		public int TournamentID { get; set; }
		
		public Tournament Tournament { get; set; }
		public Team Team1 { get; set; }
		public Team Team2 { get; set; }
		public Team Winner { get; set; }
	}

	public class Team
	{
		public int TeamID { get; set; }
		public string TeamName { get; set; }

		public ICollection<Game> Games { get; set; }
		public ICollection<TournamentTeam> TournamentTeams { get; set; }
	}
}