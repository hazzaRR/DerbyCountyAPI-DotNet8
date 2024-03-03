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

        private readonly ILeagueTableService _leagueTableRespository;

        public LeagueTableController(ILeagueTableService leagueTableRespository)
        {
            _leagueTableRespository = leagueTableRespository;
        }


        [HttpGet]
        public async Task<IActionResult> GetLeagueTable()
        {

            var leagueTable = await _leagueTableRespository.GetLeagueTableAsync();
            
            return Ok(leagueTable);
        }

        [HttpGet]
        [Route("/derby-county")]

        public async Task<IActionResult> GetDerbyPosition()
        {
            var derbyPosition = await _leagueTableRespository.GetDerbyPositionAsync();

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
            var teamInLeaguePosition = await _leagueTableRespository.GetTeamInLeaguePositionAsync(id);

            if (teamInLeaguePosition == null)
            {
                return NotFound();
            }

            return Ok(teamInLeaguePosition);
        }
    }
}
