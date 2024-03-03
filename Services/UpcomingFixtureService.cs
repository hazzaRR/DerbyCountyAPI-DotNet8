using DerbyCountyAPI.Models;
using DerbyCountyAPI.Interfaces;

namespace DerbyCountyAPI.Repository

{
    public class UpcomingFixtureService : IUpcomingFixtureService
    {

    private readonly DerbycountyContext _context;
    
    public UpcomingFixtureService(DerbycountyContext context)
    {
        _context = context;

    }

        public List<UpcomingFixture> GetAllUpcomingFixtures()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCompetition()
        {
            throw new NotImplementedException();
        }

        public List<UpcomingFixture> GetFixturesByCompetition(string competition)
        {
            throw new NotImplementedException();
        }

        public List<UpcomingFixture> GetFixturesByCompetitionAndStadium(string competiton, string stadium)
        {
            throw new NotImplementedException();
        }

        public List<UpcomingFixture> GetFixturesByCompetitionAndStadiumAndTeam(string competiton, string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public List<UpcomingFixture> GetFixturesByCompetitionAndTeam(string competiton, string team)
        {
            throw new NotImplementedException();
        }

        public List<UpcomingFixture> GetFixturesByStadium(string stadium)
        {
            throw new NotImplementedException();
        }

        public List<UpcomingFixture> GetFixturesByStadiumAndTeam(string stadium, string team)
        {
            throw new NotImplementedException();
        }

        public List<UpcomingFixture> GetFixturesByTeam(string team)
        {
            throw new NotImplementedException();
        }

        public UpcomingFixture GetNextFixture()
        {
            throw new NotImplementedException();
        }

        public List<string> GetTeams()
        {
            throw new NotImplementedException();
        }

        public List<string> GetTeamsInCompetition()
        {
            throw new NotImplementedException();
        }
    }
}
