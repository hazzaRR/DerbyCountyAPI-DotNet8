using DerbyCountyAPI.Models;
using DerbyCountyAPI.Interfaces;

namespace DerbyCountyAPI.Repository
{
    public class MatchResultService : IMatchResultService
    {

        private readonly DerbycountyContext _context;

        public MatchResultService(DerbycountyContext context)
        {
            _context = context; 
        }

        public List<MatchResult> GetAllMatchResults()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCompetitionsPlayedIn()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCompetitionsPlayedInBySeason(string season)
        {
            throw new NotImplementedException();
        }

        public List<string> GetCompetitionsPlayedInByTeam(string team)
        {
            throw new NotImplementedException();
        }

        public string GetCurrentSeason()
        {
            throw new NotImplementedException();
        }

        public MatchResult GetLatestMatchResult()
        {
            throw new NotImplementedException();
        }

        public MatchResult GetMatchResultById()
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsByCompetition(string competition)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsByCompetitionAndStadium(string competition, string stadium)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsByCompetitionAndStadiumAndTeam(string competition, string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsByCompetitionAndTeam(string competition, string team)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsByResult(string result)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsBySeason(string season)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsBySeasonAndCompetition(string season, string competition)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsBySeasonAndCompetitionAndStadium(string season, string competition, string stadium)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsBySeasonAndCompetitionAndStadiumAndTeam(string season, string competition, string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsBySeasonAndCompetitionAndStadiumAndTeamAndResult(string season, string competition, string stadium, string team, string result)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsBySeasonAndCompetitionAndTeam(string season, string competition, string team)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsBySeasonAndStadium(string season, string stadium)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsBySeasonAndStadiumAndTeam(string season, string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> getMatchResultsBySeasonAndTeam(string season, string team)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsByStadium(string stadium)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsByStadiumAndTeam(string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public List<MatchResult> GetMatchResultsByTeam(string team)
        {
            throw new NotImplementedException();
        }

        public List<string> GetRecord()
        {
            throw new NotImplementedException();
        }

        public List<string> GetRecordbyTeam(string team)
        {
            throw new NotImplementedException();
        }

        public List<string> GetSeasonsPlayedIn()
        {
            throw new NotImplementedException();
        }

        public List<string> GetTeamsPlayedAgainst()
        {
            throw new NotImplementedException();
        }

        public List<string> GetTeamsPlayedAgainstByCompetition(string competition)
        {
            throw new NotImplementedException();
        }

        public List<string> GetTeamsPlayedAgainstBySeason(string season)
        {
            throw new NotImplementedException();
        }

        public List<string> GetTeamsPlayedAgainstBySeasonAndCompetition(string season, string competition)
        {
            throw new NotImplementedException();
        }

        public List<string> GetTeamsPlayedAgainstBySeasonAndTeam(string season, string team)
        {
            throw new NotImplementedException();
        }
    }
}
