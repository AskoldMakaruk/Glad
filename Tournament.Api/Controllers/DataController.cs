using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tournament.Api.Services;

namespace Tournament.Api.Controllers
{
	[Route("[controller]")]
	public class DataController : Controller
	{
		private readonly Context _context;

		public DataController(Context context)
		{
			_context = context;
		}

		[HttpGet("all")]
		public IActionResult GetAllTournaments()
		{
			return Json(_context.Tournaments.ToArray());
		}

		[HttpPost("add")]
		public IActionResult AddTournament(string name, int roundCount, int pricepool)
		{
			_context.Tournaments.Add(new Model.Championship
			{
				RoundCount = roundCount,
				TournamentName = name,
				TournamentPrizePool = pricepool
			});
			
			return Ok();
		}
	}
}