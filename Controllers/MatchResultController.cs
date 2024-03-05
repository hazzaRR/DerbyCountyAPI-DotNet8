using Microsoft.AspNetCore.Mvc;
using DerbyCountyAPI.Interfaces;
using DerbyCountyAPI.Models;

namespace DerbyCountyAPI.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchResultController : ControllerBase
    {

        private readonly IMatchResultService _matchResultRepository;


        public MatchResultController(IMatchResultService matchResultRepository)
        {
            _matchResultRepository = matchResultRepository; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatches()
        {

            var matches = await _matchResultRepository.GetAllMatchResults();
            return Ok(matches);

        }

        [HttpGet("current-season")]
        public async Task<IActionResult> GetCurrentSeason()
        {

            var season = await _matchResultRepository.GetCurrentSeason();
            return Ok(season);

        } 
        
        
        
        [HttpGet("seasons")]
        public async Task<IActionResult> GetSeasons()
        {

            var seasons = await _matchResultRepository.GetSeasonsPlayedIn();
            return Ok(seasons);

        }

        [HttpGet("record")]
        public async Task<IActionResult> GetRecord([FromQuery] string? team)
        {

            List<String> record;
            if (team != null)
            {
                record = await _matchResultRepository.GetRecordbyTeam(team);
            }

            else
            {
                record = await _matchResultRepository.GetRecord();
            }

            return Ok(record);

        }

        [HttpGet("latest-match")]
        public async Task<IActionResult> GetLatestMatch()
        {

            var latestMatch = await _matchResultRepository.GetLatestMatchResult();

            return Ok(latestMatch);
        }

        [HttpGet("competitions")]
        public async Task<IActionResult> GetCompetitions([FromQuery] string? season, [FromQuery] string? team)
        {
            var competitions = await _matchResultRepository.GetCompetitionsPlayedIn(season, team);

            return Ok(competitions);
        }

        [HttpGet("all-teams-played-against")]
        public async Task<IActionResult> GetTeamsPlayedAgainst([FromQuery] string? season, [FromQuery] string? competition)
        {


            var teams = await _matchResultRepository.GetTeamsPlayedAgainst(season, competition);

            return Ok(teams);
        }

        [HttpGet("find")]
        public async Task<IActionResult> GetMatches([FromQuery] string? season,
            [FromQuery] string? competiton, [FromQuery] string? stadium,
            [FromQuery] string? team, [FromQuery] string? result) 
        {

            var matches = await _matchResultRepository.GetMatchResultsByQuery(season, competiton, stadium, team, result);

            return Ok(matches);
        }
    }
}
