using DerbyCountyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DerbyCountyAPI.Interfaces;

namespace DerbyCountyAPI.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchResultController : ControllerBase
    {

        private readonly DerbycountyContext _context;
        private readonly IMatchResultService _matchResultRepository;


        public MatchResultController(DerbycountyContext context, IMatchResultService matchResultRepository)
        {
            _context = context;
            _matchResultRepository = matchResultRepository; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatches()
        {

            var matches = await _context.MatchResults.ToListAsync();
            return Ok(matches);

        }

        [HttpGet]
        [Route("/find")]
        public async Task<IActionResult> GetMatches([FromQuery] string? season,
            [FromQuery] string? competiton, [FromQuery] string? stadium,
            [FromQuery] string? team, [FromQuery] string? result) {

            Console.WriteLine(season == null);
            Console.WriteLine(competiton == null);
            Console.WriteLine(stadium == null);
            Console.WriteLine(team == null);
            Console.WriteLine(result == null);
            return Ok();
        }
    }
}
