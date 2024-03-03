using DerbyCountyAPI.Interfaces;
using DerbyCountyAPI.Models;

namespace DerbyCountyAPI.Repository
{
    public class LeagueTableService: ILeagueTableService
    {

        private readonly DerbycountyContext _context;

        public LeagueTableService(DerbycountyContext context)
        {
            _context = context; 
        }

        public LeagueTable GetDerbyPosition()
        {
            throw new NotImplementedException();
        }

        public List<LeagueTable> GetLeagueTable()
        {
            throw new NotImplementedException();
        }

        public LeagueTable GetTeamInLeaguePosition(int position)
        {
            throw new NotImplementedException();
        }
    }
}
