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
        private readonly IUpcomingFixtureRepository _upcomingFixtureRepository;

        public UpcomingFixtureController(DerbycountyContext context, IUpcomingFixtureRepository upcomingFixtureRepository)
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
