using DerbyCountyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DerbyCountyAPI.Interfaces;

namespace DerbyCountyAPI.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchResultController : ControllerBase
    {

        private readonly DerbycountyContext _context;
        private readonly IMatchResultRepository _matchResultRepository;


        public MatchResultController(DerbycountyContext context, IMatchResultRepository matchResultRepository)
        {
            _context = context;
            _matchResultRepository = matchResultRepository; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatches()
        {

            var matches = await _context.MatchResults.ToListAsync();
            return Ok(matches);

        }
    }
}
