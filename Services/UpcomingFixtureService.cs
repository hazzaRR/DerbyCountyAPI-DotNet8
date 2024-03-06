using DerbyCountyAPI.Models;
using DerbyCountyAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DerbyCountyAPI.Repository

{
    public class UpcomingFixtureService : IUpcomingFixtureService
    {

    private readonly DerbycountyContext _context;
    
    public UpcomingFixtureService(DerbycountyContext context)
    {
        _context = context;

    }

        public async Task<List<UpcomingFixture>> GetAllUpcomingFixtures()
        {
            return await _context.UpcomingFixtures.OrderBy(fixture => fixture.Kickoff).ToListAsync();
        }

        public async Task<List<string?>> GetCompetitions()
        {
            return await _context.UpcomingFixtures.Select(fixture => fixture.Competition).Distinct().ToListAsync();
        }

        public async Task<List<UpcomingFixture>> GetFixturesByQuery(string ?competition, string? stadium, string? team)
        {
            var query = _context.UpcomingFixtures.AsQueryable();

            if (competition != null)
            {
                query = query.Where(fixture => fixture.Competition == competition);
            }

            if (stadium != null)
            {
                query = query.Where(fixture => fixture.Stadium == stadium);
            }

            if (team != null)
            {
                query = query.Where(fixture => fixture.HomeTeam == team || fixture.AwayTeam == team);
            }

            return await query
                .ToListAsync();
        }

        public async Task<UpcomingFixture?> GetNextFixture()
        {
            return await _context.UpcomingFixtures.OrderBy(fixture => fixture.Kickoff).FirstOrDefaultAsync();
        }

        public async Task<List<string?>> GetTeams(string? competition)
        {
            var query = _context.UpcomingFixtures.AsQueryable();


            if (competition != null)
            {
                query = query.Where(fixture => fixture.Competition == competition);
            }


            return await query.Where(fixture => fixture.HomeTeam != "Derby County")
            .Select(fixture => fixture.HomeTeam )
            .Distinct()
            .Union(query
                .Where(fixture => fixture.AwayTeam != "Derby County")
                .Select(fixture => fixture.AwayTeam)
                .Distinct())
            .OrderBy(team => team)
            .ToListAsync();
        }

    }
}
