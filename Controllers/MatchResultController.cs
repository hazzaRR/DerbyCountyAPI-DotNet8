using DerbyCountyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DerbyCountyAPI.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchResultController : ControllerBase
    {

        private readonly DerbycountyContext _context;


        public MatchResultController(DerbycountyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllMatches()
        {

            var matches = _context.MatchResults.ToList();
            return Ok(matches);

        }
    }
}
