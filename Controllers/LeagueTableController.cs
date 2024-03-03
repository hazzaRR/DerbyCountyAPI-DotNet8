using DerbyCountyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DerbyCountyAPI.Controllers
{
    [Route("api/league-table")]
    [ApiController]
    public class LeagueTableController : ControllerBase
    {

        private readonly DerbycountyContext _context;

        public LeagueTableController(DerbycountyContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetLeagueTable()
        {

            var leagueTable = _context.LeagueTables.ToList();

            return Ok(leagueTable);
        }
    }
}
