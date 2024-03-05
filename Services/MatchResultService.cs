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

        public async Task<List<MatchResult>> GetMatchResultsByQuery(string? season, string? competition, string? stadium, string? team, string? result)
        {
            var query = _context.MatchResults.AsQueryable();

            if (season != null)
            {
                query = query.Where(match => match.Season == season);
            }
            if (competition != null)
            {
                query = query.Where(match => match.Competition == competition);
            }
            if (stadium != null)
            {
                query = query.Where(match => match.Stadium == stadium);
            }
            if (team != null)
            {
                query = query.Where(match => match.HomeTeam == team || match.AwayTeam == team);
            }
            if (result != null)
            {
                query = query.Where(match => match.Result == result);
            }

            var matches = await query.ToListAsync();

            return matches;
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

        public async Task<List<string?>> GetTeamsPlayedAgainst(string? season, string? competition)
        {
            var query = _context.MatchResults.AsQueryable();

            if (season != null )
            {
                query = query.Where(match => match.Season == season);  
            }
            if (competition != null)
            {
                query = query.Where(match => match.Competition == competition);
            }

            var matches = await query
                .Where(match => match.HomeTeam != "Derby County")
                .Select(match => match.HomeTeam)
                .Union(
                query
                .Where(match => match.AwayTeam != "Derby County")
                .Select(match => match.AwayTeam)
                )
                .Distinct()
                .ToListAsync();

            return matches;
        }

    }
}
