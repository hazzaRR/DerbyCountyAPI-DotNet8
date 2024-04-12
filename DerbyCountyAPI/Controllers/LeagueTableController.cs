using DerbyCountyAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DerbyCountyAPI.Controllers
{
    [Route("api/league-table")]
    [ApiController]
    public class LeagueTableController : ControllerBase
    {

        private readonly ILeagueTableService _leagueTableService;

        public LeagueTableController(ILeagueTableService leagueTableService)
        {
            _leagueTableService = leagueTableService;
        }


        [HttpGet]
        public async Task<IActionResult> GetLeagueTable()
        {

            var leagueTable = await _leagueTableService.GetLeagueTableAsync();
            
            return Ok(leagueTable);
        }

        [HttpGet]
        [Route("/derby-county")]

        public async Task<IActionResult> GetDerbyPosition()
        {
            var derbyPosition = await _leagueTableService.GetDerbyPositionAsync();

            if (derbyPosition == null)
            {
                return NotFound();
            }

            return Ok(derbyPosition);
        }

        [HttpGet]
        [Route("/league-position/{id}")]

        public async Task<IActionResult> GetLeaguePosition([FromRoute] int id)
        {
            var teamInLeaguePosition = await _leagueTableService.GetTeamInLeaguePositionAsync(id);

            if (teamInLeaguePosition == null)
            {
                return NotFound();
            }

            return Ok(teamInLeaguePosition);
        }
    }
}
