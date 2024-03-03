using DerbyCountyAPI.Models;
using DerbyCountyAPI.Interfaces;

namespace DerbyCountyAPI.Repository

{
    public class UpcomingFixtureRepository: IUpcomingFixtureService
    {

    private readonly DerbycountyContext _context;
    
    public UpcomingFixtureRepository(DerbycountyContext context)
    {
        _context = context;

    }
    }
}
