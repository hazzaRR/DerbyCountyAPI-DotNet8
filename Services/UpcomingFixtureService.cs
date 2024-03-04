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

        public Task<List<UpcomingFixture>> GetFixturesByCompetition(string competition)
        {
            throw new NotImplementedException();
        }

        public Task<List<UpcomingFixture>> GetFixturesByCompetitionAndStadium(string competiton, string stadium)
        {
            throw new NotImplementedException();
        }

        public Task<List<UpcomingFixture>> GetFixturesByCompetitionAndStadiumAndTeam(string competiton, string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<UpcomingFixture>> GetFixturesByCompetitionAndTeam(string competiton, string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<UpcomingFixture>> GetFixturesByStadium(string stadium)
        {
            throw new NotImplementedException();
        }

        public Task<List<UpcomingFixture>> GetFixturesByStadiumAndTeam(string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public Task<List<UpcomingFixture>> GetFixturesByTeam(string team)
        {
            throw new NotImplementedException();
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
