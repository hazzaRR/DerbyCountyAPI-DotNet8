using DerbyCountyAPI.Models;
namespace DerbyCountyAPI.Interfaces

{
    public interface IMatchResultService
    {

        Task<MatchResult> GetMatchResultById();

        Task<MatchResult> GetLatestMatchResult();

        Task<string?> GetCurrentSeason();

        Task<List<MatchResult>> GetAllMatchResults();

        Task<List<MatchResult>> GetMatchResultsByQuery(string? season, string? competition, string? stadium, string? team, string? result);

        Task<List<string?>> GetTeamsPlayedAgainst(string? season, string? competition);

        Task<List<string>> GetSeasonsPlayedIn();

        Task<List<string>> GetCompetitionsPlayedIn();

        Task<List<string>> GetCompetitionsPlayedInBySeason(string season);

        Task<List<string>> GetCompetitionsPlayedInByTeam(string team);

        Task<List<string>> GetCompetitionsPlayedInBySeasonAndTeam(string season, string team);

        Task<List<string>> GetRecord();

        Task<List<string>> GetRecordbyTeam(string team);

    }
}
