using DerbyCountyAPI.Models;
using DerbyCountyAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DerbyCountyAPI.Repository
{
    public class MatchResultService : IMatchResultService
    {

        private readonly DerbycountyContext _context;

        public MatchResultService(DerbycountyContext context)
        {
            _context = context; 
        }

        public async Task<List<MatchResult>> GetAllMatchResults()
        {
            return await _context.MatchResults.ToListAsync();
        }

        public Task<List<string>> GetCompetitionsPlayedIn()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetCompetitionsPlayedInBySeason(string season)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetCompetitionsPlayedInBySeasonAndTeam(string season, string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetCompetitionsPlayedInByTeam(string team)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> GetCurrentSeason()
        {
            return await _context.MatchResults.Select(match => match.Season).OrderByDescending(season => season).FirstOrDefaultAsync();
        }

        public Task<MatchResult> GetLatestMatchResult()
        {
            throw new NotImplementedException();
        }

        public Task<MatchResult> GetMatchResultById()
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsByCompetition(string competition)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsByCompetitionAndStadium(string competition, string stadium)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsByCompetitionAndStadiumAndTeam(string competition, string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsByCompetitionAndTeam(string competition, string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsByResult(string result)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsBySeason(string season)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsBySeasonAndCompetition(string season, string competition)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsBySeasonAndCompetitionAndStadium(string season, string competition, string stadium)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsBySeasonAndCompetitionAndStadiumAndTeam(string season, string competition, string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MatchResult>> GetMatchResultsBySeasonAndCompetitionAndStadiumAndTeamAndResult(string season, string competition, string stadium, string team, string result)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsBySeasonAndCompetitionAndTeam(string season, string competition, string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsBySeasonAndStadium(string season, string stadium)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsBySeasonAndStadiumAndTeam(string season, string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> getMatchResultsBySeasonAndTeam(string season, string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsByStadium(string stadium)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsByStadiumAndTeam(string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<MatchResult>> GetMatchResultsByTeam(string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetRecord()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetRecordbyTeam(string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetSeasonsPlayedIn()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetTeamsPlayedAgainst()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetTeamsPlayedAgainstByCompetition(string competition)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetTeamsPlayedAgainstBySeason(string season)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetTeamsPlayedAgainstBySeasonAndCompetition(string season, string competition)
        {
            throw new NotImplementedException();
        }

    }
}
