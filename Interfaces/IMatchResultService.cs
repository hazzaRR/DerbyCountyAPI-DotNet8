using DerbyCountyAPI.Models;
namespace DerbyCountyAPI.Interfaces

{
    public interface IMatchResultService
    {

        MatchResult GetMatchResultById();

        MatchResult GetLatestMatchResult();

        string GetCurrentSeason();

        Task<List<MatchResult>> GetMatchResultsBySeasonAndCompetitionAndStadiumAndTeamAndResult(String season, String competition, String stadium, String team, String result);

        Task<List<MatchResult>> GetMatchResultsBySeasonAndCompetitionAndStadiumAndTeam(String season, String competition, String stadium, String team);

        Task<List<MatchResult>> GetMatchResultsBySeasonAndCompetitionAndStadium(String season, String competition, String stadium);

        Task<List<MatchResult>> GetMatchResultsBySeasonAndCompetitionAndTeam(String season, String competition, String team);

        Task<List<MatchResult>> GetMatchResultsBySeasonAndStadiumAndTeam(String season, String stadium, String team);

        Task<List<MatchResult>> GetMatchResultsByCompetitionAndStadiumAndTeam(String competition, String stadium, String team);

        Task<List<MatchResult>> GetMatchResultsBySeasonAndCompetition(String season, String competition);

        Task<List<MatchResult>> GetMatchResultsBySeasonAndStadium(String season, String stadium);

        Task<List<MatchResult>> getMatchResultsBySeasonAndTeam(String season, String team);

        Task<List<MatchResult>> GetMatchResultsByCompetitionAndStadium(String competition, String stadium);

        Task<List<MatchResult>> GetMatchResultsByCompetitionAndTeam(String competition, String team);

        Task<List<MatchResult>> GetMatchResultsByStadiumAndTeam(String stadium, String team);

        Task<List<MatchResult>> GetMatchResultsBySeason(String season);

        Task<List<MatchResult>> GetMatchResultsByCompetition(String competition);

        Task<List<MatchResult>> GetMatchResultsByStadium(String stadium);

        Task<List<MatchResult>> GetMatchResultsByTeam(String team);

        Task<List<MatchResult>> GetMatchResultsByResult(String result);

        Task<List<MatchResult>> GetAllMatchResults();

        Task<List<string>> GetTeamsPlayedAgainst();
        Task<List<string>> GetTeamsPlayedAgainstBySeason(string season);

        Task<List<string>> GetTeamsPlayedAgainstBySeasonAndCompetition(string season, string competition);

        Task<List<string>> GetTeamsPlayedAgainstByCompetition(string competition);

        Task<List<string>> GetTeamsPlayedAgainstBySeasonAndTeam(string season, string team);

        Task<List<string>> GetSeasonsPlayedIn();

        Task<List<string>> GetCompetitionsPlayedIn();

        Task<List<string>> GetCompetitionsPlayedInBySeason(string season);

        Task<List<string>> GetCompetitionsPlayedInByTeam(string team);


        Task<List<string>> GetRecord();
       Task<List<string>> GetRecordbyTeam(string team);

    }
}
