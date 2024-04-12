using DerbyCountyAPI.Models;

namespace DerbyCountyAPI.Interfaces
{
    public interface IUpcomingFixtureService
    {

        Task<UpcomingFixture?> GetNextFixture();
        Task<List<UpcomingFixture>> GetAllUpcomingFixtures();
        Task<List<UpcomingFixture>> GetFixturesByQuery(string? competition, string? stadium, string? team);

        Task<List<string?>> GetCompetitions();
        Task<List<string?>> GetTeams(string? competition);
    }
}
