using DerbyCountyAPI.dto;
using DerbyCountyAPI.Models;
namespace DerbyCountyAPI.Interfaces

{
    public interface IMatchResultService
    {

        Task<MatchResult> GetMatchResultById();

        Task<MatchResult?> GetLatestMatchResult();

        Task<string?> GetCurrentSeason();

        Task<List<MatchResult>> GetAllMatchResults();

        Task<List<MatchResult>> GetMatchResultsByQuery(string? season, string? competition, string? stadium, string? team, string? result);

        Task<List<string?>> GetTeamsPlayedAgainst(string? season, string? competition);

        Task<List<string>> GetSeasonsPlayedIn();

        Task<List<string?>> GetCompetitionsPlayedIn(string? season, string? team);

        Task<List<RecordDTO>> GetRecord(string? team);

    }
}
