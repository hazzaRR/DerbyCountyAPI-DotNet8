using DerbyCountyAPI.Models;

namespace DerbyCountyAPI.Interfaces
{
    public interface IUpcomingFixtureService
    {

        Task<UpcomingFixture> GetNextFixture();
        Task<List<UpcomingFixture>> GetAllUpcomingFixtures();
        Task<List<UpcomingFixture>> GetFixturesByTeam(string team);
        Task<List<UpcomingFixture>> GetFixturesByStadium(string stadium);
        Task<List<UpcomingFixture>> GetFixturesByCompetition(string competition);
        Task<List<UpcomingFixture>> GetFixturesByStadiumAndTeam(string stadium, string team);
        Task<List<UpcomingFixture>> GetFixturesByCompetitionAndTeam(string competition, string team);
        Task<List<UpcomingFixture>> GetFixturesByCompetitionAndStadium(string competition, string stadium);
        Task<List<UpcomingFixture>> GetFixturesByCompetitionAndStadiumAndTeam(string competition, string stadium, string team);

        Task<List<String?>> GetCompetitions();
        Task<List<String>> GetTeamsInCompetition();
        Task<List<String>> GetTeams();
    }
}
