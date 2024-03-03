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

        public UpcomingFixtureController(DerbycountyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllFixtures()
        {
            var fixtures = _context.UpcomingFixtures.ToList();

            return Ok(fixtures);
        }
    }
}
