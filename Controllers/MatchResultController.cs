using Microsoft.AspNetCore.Mvc;
using DerbyCountyAPI.Interfaces;
using System.Text;

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

        [HttpGet("matchId/{id}")]
        public async Task<IActionResult> GetMatchById([FromRoute] int id)
        {

            var match = await _matchResultRepository.GetMatchResultById(id);

            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);

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

            var record = await _matchResultRepository.GetRecord(team);

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

        [HttpGet("matches.csv")]
        public async Task<IActionResult> GetMatchesAsCsvFile([FromQuery] string? season,
    [FromQuery] string? competiton, [FromQuery] string? stadium,
    [FromQuery] string? team, [FromQuery] string? result)
        {

            var matches = await _matchResultRepository.GetMatchResultsByQuery(season, competiton, stadium, team, result);

            // Create a CSV string
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("MatchId,HomeTeam,AwayTeam,Kickoff,HomeScore,AwayScore,Result,PenaltiesScore,Season,Competition,Stadium");

            foreach (var match in matches)
            {
                csvBuilder.AppendLine($"{match.Id},{match.HomeTeam},{match.AwayTeam},{match.Kickoff},{match.HomeScore},{match.AwayScore},{match.Result},{match.PenaltiesScore},{match.Season},{match.Competition},{match.Stadium}");
            }

            // Convert the CSV string to a byte array
            byte[] csvBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());

            // Return the CSV file as a response
            return File(csvBytes, "text/csv", "matches.csv");

        }
    }
}
