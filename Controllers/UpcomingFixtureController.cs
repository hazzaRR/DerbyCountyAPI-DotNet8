using DerbyCountyAPI.Interfaces;
using DerbyCountyAPI.Models;
using Microsoft.AspNetCore.Http;
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


        [HttpGet]
        [Route("/competitions")]

        public async Task<IActionResult> GetCompetitions()
        {
            var competitions = await _upcomingFixtureRepository.GetCompetitions();

            if (competitions == null)
            {
                return NotFound();
            }

            return Ok(competitions);
        }
    }
}
