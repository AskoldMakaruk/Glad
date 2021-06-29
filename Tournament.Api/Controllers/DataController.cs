using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tournament.Api.Services;
using Tournament.Model;

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
		public IActionResult AddTournament([FromBody] Championship championship)
		{
			_context.Tournaments.Add(championship);
			_context.SaveChanges();
			return Ok();
		}
	}
}