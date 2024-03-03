using DerbyCountyAPI.Interfaces;
using DerbyCountyAPI.Models;

namespace DerbyCountyAPI.Repository
{
    public class LeagueTableRepository: ILeagueTableRespository
    {

        private readonly DerbycountyContext _context;

        public LeagueTableRepository(DerbycountyContext context)
        {
            _context = context; 
        }
    }
}
