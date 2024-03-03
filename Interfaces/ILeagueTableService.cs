using DerbyCountyAPI.Models;

namespace DerbyCountyAPI.Interfaces
{
    public interface ILeagueTableService
    {

        List<LeagueTable> GetLeagueTable();

        LeagueTable GetDerbyPosition();

        LeagueTable GetTeamInLeaguePosition(int position);
    }
}
