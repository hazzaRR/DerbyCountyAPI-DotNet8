using DerbyCountyAPI.Models;
using DerbyCountyAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<UpcomingFixture>> GetFixturesByCompetition(string competition)
        {
            return await _context.UpcomingFixtures
                .Where(fixture => fixture.Competition  == competition)
                .ToListAsync(); 
        }

        public async Task<List<UpcomingFixture>> GetFixturesByCompetitionAndStadium(string competition, string stadium)
        {
            return await _context.UpcomingFixtures
                .Where(fixture => fixture.Competition == competition && fixture.Stadium == stadium)
                .ToListAsync();
        }

        public async Task<List<UpcomingFixture>> GetFixturesByCompetitionAndStadiumAndTeam(string competition, string stadium, string team)
        {
            return await _context.UpcomingFixtures
                .Where(fixture => fixture.Competition == competition 
                && fixture.Stadium == stadium 
                && (fixture.HomeTeam == team || fixture.AwayTeam == team))
                .ToListAsync();
        }

        public async Task<List<UpcomingFixture>> GetFixturesByCompetitionAndTeam(string competition, string team)
        {
            return await _context.UpcomingFixtures
                .Where(fixture => fixture.Competition == competition
                && (fixture.HomeTeam == team || fixture.AwayTeam == team))
                .ToListAsync();
        }

        public async Task<List<UpcomingFixture>> GetFixturesByStadium(string stadium)
        {
            return await _context.UpcomingFixtures
            .Where(fixture => fixture.Stadium == stadium)
            .ToListAsync();
        }

        public async Task<List<UpcomingFixture>> GetFixturesByStadiumAndTeam(string stadium, string team)
        {
            return await _context.UpcomingFixtures
            .Where(fixture => fixture.Stadium == stadium
            && (fixture.HomeTeam == team || fixture.AwayTeam == team))
            .ToListAsync();
        }

        public async Task<List<UpcomingFixture>> GetFixturesByTeam(string team)
        {
            return await _context.UpcomingFixtures
            .Where(fixture => (fixture.HomeTeam == team || fixture.AwayTeam == team))
            .ToListAsync();
        }

        public Task<UpcomingFixture> GetNextFixture()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetTeams()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetTeamsInCompetition()
        {
            throw new NotImplementedException();
        }
    }
}
