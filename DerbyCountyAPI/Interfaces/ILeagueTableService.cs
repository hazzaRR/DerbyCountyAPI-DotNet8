using DerbyCountyAPI.Models;

namespace DerbyCountyAPI.Interfaces
{
    public interface ILeagueTableService
    {

        Task<List<LeagueTable>> GetLeagueTableAsync();

        Task<LeagueTable?> GetDerbyPositionAsync();

        Task<LeagueTable?> GetTeamInLeaguePositionAsync(int position);
    }
}
