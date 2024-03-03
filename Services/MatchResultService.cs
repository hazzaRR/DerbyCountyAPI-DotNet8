using DerbyCountyAPI.Models;
using DerbyCountyAPI.Interfaces;

namespace DerbyCountyAPI.Repository
{
    public class MatchResultRepository: IMatchResultService
    {

        private readonly DerbycountyContext _context;

        public MatchResultRepository(DerbycountyContext context)
        {
            _context = context; 
        }


    }
}
