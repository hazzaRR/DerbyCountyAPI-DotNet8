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

        private readonly DerbycountyContext _context;
        private readonly IUpcomingFixtureService _upcomingFixtureRepository;

        public UpcomingFixtureController(DerbycountyContext context, IUpcomingFixtureService upcomingFixtureRepository)
        {
            _context = context;
            _upcomingFixtureRepository = upcomingFixtureRepository;
        }

        [HttpGet]
        public IActionResult GetAllFixtures()
        {
            var fixtures = _context.UpcomingFixtures.ToList();

            return Ok(fixtures);
        }
    }
}
