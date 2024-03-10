using DerbyCountyAPI.Interfaces;
using DerbyCountyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DerbyCountyAPI.Service
{
    public class LeagueTableService : ILeagueTableService
    {

        private readonly DerbycountyContext _context;

        public LeagueTableService(DerbycountyContext context)
        {
            _context = context; 
        }

        public async Task<LeagueTable?> GetDerbyPositionAsync()
        {

            return await _context.LeagueTables.FirstOrDefaultAsync(row => row.Team == "Derby County");
        }

        public async Task<List<LeagueTable>> GetLeagueTableAsync()
        {
            return await _context.LeagueTables.OrderBy(row => row.LeaguePosition).ToListAsync();
        }

        public async Task<LeagueTable?> GetTeamInLeaguePositionAsync(int position)
        {
            return await _context.LeagueTables.Where(row => row.LeaguePosition == position).FirstOrDefaultAsync();
        }
    }
}
