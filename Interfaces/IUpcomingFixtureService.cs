using DerbyCountyAPI.Models;

namespace DerbyCountyAPI.Interfaces
{
    public interface IUpcomingFixtureService
    {

        UpcomingFixture GetNextFixture();
        List<UpcomingFixture> GetAllUpcomingFixtures();
        List<UpcomingFixture> GetFixturesByTeam(string team);

        List<UpcomingFixture> GetFixturesByStadium(string stadium);
        List<UpcomingFixture> GetFixturesByCompetition(string competition);
        List<UpcomingFixture> GetFixturesByStadiumAndTeam(string stadium, string team);
        List<UpcomingFixture> GetFixturesByCompetitionAndTeam(string competiton, string team);
        List<UpcomingFixture> GetFixturesByCompetitionAndStadium(string competiton, string stadium);
        List<UpcomingFixture> GetFixturesByCompetitionAndStadiumAndTeam(string competiton, string stadium, string team);

        List<String> GetCompetition();
        List<String> GetTeamsInCompetition();
        List<String> GetTeams();
    }
}
