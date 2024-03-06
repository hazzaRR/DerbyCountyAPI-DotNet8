using DerbyCountyAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DerbyCountyAPI.Controllers
{
    [Route("api/fixture")]
    [ApiController]
    public class UpcomingFixtureController : ControllerBase
    {

        private readonly IUpcomingFixtureService _upcomingFixtureRepository;

        public UpcomingFixtureController(IUpcomingFixtureService upcomingFixtureRepository)
        {
            _upcomingFixtureRepository = upcomingFixtureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFixtures()
        {
            var fixtures = await _upcomingFixtureRepository.GetAllUpcomingFixtures();

            return Ok(fixtures);
        }


        [HttpGet("competitions")]
        public async Task<IActionResult> GetCompetitions()
        {
            var competitions = await _upcomingFixtureRepository.GetCompetitions();

            if (competitions == null)
            {
                return NotFound();
            }

            return Ok(competitions);
        }

        [HttpGet("find")]
        public async Task<IActionResult> GetFixturesByQuery([FromQuery] string? competition, [FromQuery] string? stadium, [FromQuery] string? team)
        {

            return Ok(await _upcomingFixtureRepository.GetFixturesByQuery(competition, stadium, team));
        }

        [HttpGet("next-fixture")]
        public async Task<IActionResult> GetNextFixture()
        {
            var nextFixture = await _upcomingFixtureRepository.GetNextFixture();

            if (nextFixture == null)
            {
                return NotFound();
            }

            return Ok(nextFixture);
        }

        [HttpGet("teams")]
        public async Task<IActionResult> GetAllTeams(string? competition)

        {
            
            var teams = await _upcomingFixtureRepository.GetTeams(competition);    
          
            if (teams == null)
            {
                return NotFound();
            }

            return Ok(teams);
        }
    }
}
