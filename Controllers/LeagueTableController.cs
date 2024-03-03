using DerbyCountyAPI.Interfaces;
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
        private readonly ILeagueTableService _leagueTableRespository;

        public LeagueTableController(DerbycountyContext context, ILeagueTableService leagueTableRespository)
        {
            _context = context;
            _leagueTableRespository = leagueTableRespository;
        }


        [HttpGet]
        public IActionResult GetLeagueTable()
        {

            var leagueTable = _context.LeagueTables.ToList();

            return Ok(leagueTable);
        }
    }
}
