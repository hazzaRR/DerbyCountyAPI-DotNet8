using DerbyCountyAPI.Models;
namespace DerbyCountyAPI.Interfaces

{
    public interface IMatchResultService
    {

        MatchResult GetMatchResultById();

        MatchResult GetLatestMatchResult();

        string GetCurrentSeason();

        List<MatchResult> GetMatchResultsBySeasonAndCompetitionAndStadiumAndTeamAndResult(String season, String competition, String stadium, String team, String result);

        List<MatchResult> GetMatchResultsBySeasonAndCompetitionAndStadiumAndTeam(String season, String competition, String stadium, String team);

        List<MatchResult> GetMatchResultsBySeasonAndCompetitionAndStadium(String season, String competition, String stadium);

        List<MatchResult> GetMatchResultsBySeasonAndCompetitionAndTeam(String season, String competition, String team);

        List<MatchResult> GetMatchResultsBySeasonAndStadiumAndTeam(String season, String stadium, String team);

        List<MatchResult> GetMatchResultsByCompetitionAndStadiumAndTeam(String competition, String stadium, String team);

        List<MatchResult> GetMatchResultsBySeasonAndCompetition(String season, String competition);

        List<MatchResult> GetMatchResultsBySeasonAndStadium(String season, String stadium);

        List<MatchResult> getMatchResultsBySeasonAndTeam(String season, String team);

        List<MatchResult> GetMatchResultsByCompetitionAndStadium(String competition, String stadium);

        List<MatchResult> GetMatchResultsByCompetitionAndTeam(String competition, String team);

        List<MatchResult> GetMatchResultsByStadiumAndTeam(String stadium, String team);

        List<MatchResult> GetMatchResultsBySeason(String season);

        List<MatchResult> GetMatchResultsByCompetition(String competition);

        List<MatchResult> GetMatchResultsByStadium(String stadium);

        List<MatchResult> GetMatchResultsByTeam(String team);

        List<MatchResult> GetMatchResultsByResult(String result);

        List<MatchResult> GetAllMatchResults();

        List<string> GetTeamsPlayedAgainst();
        List<string> GetTeamsPlayedAgainstBySeason(string season);

        List<string> GetTeamsPlayedAgainstBySeasonAndCompetition(string season, string competition);

        List<string> GetTeamsPlayedAgainstByCompetition(string competition);

        List<string> GetTeamsPlayedAgainstBySeasonAndTeam(string season, string team);

        List<string> GetSeasonsPlayedIn();

        List<string> GetCompetitionsPlayedIn();

        List<string> GetCompetitionsPlayedInBySeason(string season);

        List<string> GetCompetitionsPlayedInByTeam(string team);


        List<string> GetRecord();
        List<string> GetRecordbyTeam(string team);

    }
}
