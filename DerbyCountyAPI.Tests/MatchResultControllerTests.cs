using DerbyCountyAPI.Controllers;
using DerbyCountyAPI.Dto;
using DerbyCountyAPI.Interfaces;
using DerbyCountyAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Text;

namespace DerbyCountyAPI.Tests
{
    public class MatchResultControllerTests
    {

        private readonly MatchResultController _controller;
        private readonly Mock<IMatchResultService> _matchResultService;


        public MatchResultControllerTests()
        {
            _matchResultService = new Mock<IMatchResultService>();
            _controller = new MatchResultController(_matchResultService.Object);
        }


        [Fact]
        public async void GetAllMatches_ReturnsOKAndList()
        {
            //Arrange

            List<MatchResult> matches = new List<MatchResult>
                {
                    new MatchResult
                    {
                        Id = 1,
                        HomeTeam = "Derby County",
                        AwayTeam = "Nottingham Forest",
                        HomeScore = 5,
                        AwayScore = 0,
                        Competition = "Champions League",
                        Season = "2023-24",
                        Result = "W",
                        Kickoff = new DateTime(2024, 12, 29),
                    },
                                        new MatchResult
                    {
                        Id = 2,
                        HomeTeam = "Derby County",
                        AwayTeam = "Ipswich Town",
                        HomeScore = 3,
                        AwayScore = 2,
                        Competition = "Premier League",
                        Season = "2023-24",
                        Result = "W",
                        Kickoff = new DateTime(2024, 03, 22),
                    },

                };

            _matchResultService.Setup(service => service.GetAllMatchResults())
                .ReturnsAsync(matches);

            //Act

            var result = await _controller.GetAllMatches();


            //Assert

            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(matches, okResult.Value);
        }


        [Fact]
        public async void GetMatchById_ReturnsOkAndMatchResultObject()
        {
            //Arrange

            MatchResult match = new MatchResult
            {
                Id = 1,
                HomeTeam = "Derby County",
                AwayTeam = "Nottingham Forest",
                HomeScore = 5,
                AwayScore = 0,
                Competition = "Champions League",
                Season = "2023-24",
                Result = "W",
                Kickoff = new DateTime(2024, 12, 29),
            };


            _matchResultService.Setup(service => service.GetMatchResultById(match.Id))
                .ReturnsAsync(match);


            //Act

            var result = await _controller.GetMatchById(match.Id);

            //Assert

            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;


            Assert.NotNull(okResult);

            Assert.Equal(match, okResult.Value);

        }

        [Fact]
        public async void GetMatchById_ReturnsNotFound()
        {
            //Arrange

            _matchResultService.Setup(service => service.GetMatchResultById(1))
                .ReturnsAsync(() => null);

            //Act


            var result = await _controller.GetMatchById(1);

            //Assert

            Assert.IsType<NotFoundResult>(result);

            var notFoundResult = result as NotFoundResult;

            Assert.NotNull(notFoundResult);
        }


        [Fact]
        public async void GetCurrentSeason_ReturnsOkAndString()
        {
            //Arrange

            string season = "2023-24";

            _matchResultService.Setup(service => service.GetCurrentSeason())
                .ReturnsAsync(season);

            //Act

            var result = await _controller.GetCurrentSeason();

            //Assert

            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            StringDTO data = (StringDTO)okResult.Value;

            Assert.NotNull(okResult);
            Assert.Equal(season, data.Data);
        }

        [Fact]
        public async void GetSeasons_ReturnsOkAndStringList()
        {
            //Arrange

            List<string?> seasons = new List<String>
            {
                "2023-24",
                "2022-23",
                "2021-22",
                "2020-21"
            };


            _matchResultService.Setup(service => service.GetSeasonsPlayedIn())
                .ReturnsAsync(seasons);


            //Act

            var result = await _controller.GetSeasons();

            //Assert

            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);

            Assert.Equal(seasons, okResult.Value);

        }


        [Fact]
        public async void GetRecord_ReturnsOkAndRecordDTO()
        {

            //Arrange

            List<RecordDTO> record = new List<RecordDTO>
            {
                new RecordDTO()
                {
                    Count = 1,
                    Result = "W"
                },
                new RecordDTO()
                {
                    Count = 3,
                    Result = "D",

                },
                new RecordDTO()
                {
                    Count = 0,
                    Result = "L"
                }

            };


            _matchResultService.Setup(service => service.GetRecord("Nottingham Forest"))
                .ReturnsAsync(record);


            //Act

            var result = await _controller.GetRecord("Nottingham Forest");


            //Assert

            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);

            Assert.Equal(record, okResult.Value);

        }

        [Fact]
        public async void GetLatestMatch_ReturnsOkAndMatchObject()
        {
            //Arrange

            MatchResult match = new MatchResult
            {
                Id = 1,
                HomeTeam = "Derby County",
                AwayTeam = "Nottingham Forest",
                HomeScore = 5,
                AwayScore = 0,
                Competition = "Champions League",
                Season = "2023-24",
                Result = "W",
                Kickoff = new DateTime(2024, 12, 29),
            };

            _matchResultService.Setup(service => service.GetLatestMatchResult())
                .ReturnsAsync(match);

            //Act

            var result = await _controller.GetLatestMatch();

            //Assert

            Assert.IsType<OkObjectResult>(result);


            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);

            Assert.Equal(match, okResult.Value);
        }


        [Fact]
        public async void GetCompetitions_ReturnsOkAndListString()
        {
            //Arrange

            List<string?> competitions = new List<string?>
            {
                "League 1",
                "Championship",
                "European Cup"
            };

            _matchResultService.Setup(service => service.GetCompetitionsPlayedIn(null, null))
                .ReturnsAsync(competitions);


            //Act

            var result = await _controller.GetCompetitions(null, null);

            //Assert

            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);

            Assert.Equal(competitions, okResult.Value);
        }

        [Fact]
        public async void getTeamsPlayedAgainst_ReturnsOkAndListString()
        {
            //Arrange

            List<string?> teams = new List<string?>
            {
                "Nottingham Forest",
                "Leicester City",
                "Burton Albion"
            };


            _matchResultService.Setup(service => service.GetTeamsPlayedAgainst(null, null))
                .ReturnsAsync(teams);

            //Act


            var result = await _controller.GetTeamsPlayedAgainst(null, null);


            //Assert

            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);

            Assert.Equal(teams, okResult.Value);

        }


        [Fact]

        public async void GetMatchesUsingFind_ReturnsOkAndMatchResult()
        {

            //Arrange

            List<MatchResult> matches = new List<MatchResult>
                {
                    new MatchResult
                    {
                        Id = 1,
                        HomeTeam = "Derby County",
                        AwayTeam = "Nottingham Forest",
                        HomeScore = 5,
                        AwayScore = 0,
                        Competition = "Champions League",
                        Season = "2023-24",
                        Result = "W",
                        Kickoff = new DateTime(2024, 12, 29),
                    },
                                        new MatchResult
                    {
                        Id = 2,
                        HomeTeam = "Derby County",
                        AwayTeam = "Ipswich Town",
                        HomeScore = 3,
                        AwayScore = 2,
                        Competition = "Premier League",
                        Season = "2023-24",
                        Result = "W",
                        Kickoff = new DateTime(2024, 03, 22),
                    },

                };


            _matchResultService.Setup(service => service.GetMatchResultsByQuery(null, null, null, null, null))
                .ReturnsAsync(matches);


            //Act


            var result = await _controller.GetMatches(null, null, null, null, null);

            //Assert

            Assert.IsType<OkObjectResult>(result);

            var okResult = (OkObjectResult) result;


            Assert.NotNull(okResult);

            Assert.Equal(matches, okResult.Value);

        }


        [Fact]
        public async void GetMatchesByPage_ReturnsBadRequest()
        {

            //Arrange

            //Act


            var result = await _controller.GetMatchesByPage(0, 0, null, null, null, null, null);

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);


            Assert.NotNull(result);


        }

        [Fact]
        public async void GetMatchesByPage_PageNumberAndPageSizeLessThanOne_ReturnsBadRequest()
        {

            //Arrange

            //Act

            var result = await _controller.GetMatchesByPage(0, 0, null, null, null, null, null);

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);


            Assert.NotNull(result);


        }

        [Fact]
        public async void GetMatchesByPage_PageNumberLessThanOne_ReturnsBadRequest()
        {

            //Arrange


            //Act

            var result = await _controller.GetMatchesByPage(-1, 2, null, null, null, null, null);

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);


            Assert.NotNull(result);


        }

        [Fact]
        public async void GetMatchesByPage_PageSizeLessThanOne_ReturnsBadRequest()
        {

            //Arrange

            //Act


            var result = await _controller.GetMatchesByPage(2, -2, null, null, null, null, null);

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);


            Assert.NotNull(result);


        }

        [Fact]
        public async void GetMatchesByPage__ReturnsOkAndPagedResponseDTO()
        {

            //Arrange

            PagedResponseDTO<MatchResult> data = new PagedResponseDTO<MatchResult> (1, 3, 15,  new List<MatchResult>
            {
                    new MatchResult
                    {
                        Id = 1,
                        HomeTeam = "Derby County",
                        AwayTeam = "Nottingham Forest",
                        HomeScore = 5,
                        AwayScore = 0,
                        Competition = "Champions League",
                        Season = "2023-24",
                        Result = "W",
                        Kickoff = new DateTime(2024, 12, 29),
                    },
                    new MatchResult
                    {
                        Id = 2,
                        HomeTeam = "Derby County",
                        AwayTeam = "Ipswich Town",
                        HomeScore = 3,
                        AwayScore = 2,
                        Competition = "Premier League",
                        Season = "2023-24",
                        Result = "W",
                        Kickoff = new DateTime(2024, 03, 22),
                    },
                    new MatchResult
                    {
                        Id = 3,
                        HomeTeam = "Derby County",
                        AwayTeam = "Norwich CIty",
                        HomeScore = 5,
                        AwayScore = 4,
                        Competition = "Premier League",
                        Season = "2023-24",
                        Result = "W",
                        Kickoff = new DateTime(2024, 04, 21),
                    }
                }
            );


            _matchResultService.Setup(service => service.GetMatchResultsByQueryWithPagination(1, 3, null, null, null, null, null))
                .ReturnsAsync(data);


            //Act

            var result = await _controller.GetMatchesByPage(1, 3, null, null, null, null, null);

            //Assert

            Assert.IsType<OkObjectResult>(result);


            var okResult = (OkObjectResult)result;

            Assert.NotNull(okResult);

            Assert.Equal(data, okResult.Value);

        }


        [Fact]

        public async void GetMatchesAsCSVFile_ReturnsFile()
        {

            //Arrange

            List<MatchResult> matches = new List<MatchResult>
                {
                    new MatchResult
                    {
                        Id = 1,
                        HomeTeam = "Derby County",
                        AwayTeam = "Nottingham Forest",
                        HomeScore = 5,
                        AwayScore = 0,
                        Competition = "Champions League",
                        Season = "2023-24",
                        Result = "W",
                        Kickoff = new DateTime(2024, 12, 29),
                    },
                                        new MatchResult
                    {
                        Id = 2,
                        HomeTeam = "Derby County",
                        AwayTeam = "Ipswich Town",
                        HomeScore = 3,
                        AwayScore = 2,
                        Competition = "Premier League",
                        Season = "2023-24",
                        Result = "W",
                        Kickoff = new DateTime(2024, 03, 22),
                    },

                };


            _matchResultService.Setup(service => service.GetMatchResultsByQuery(null, null, null, null, null))
                .ReturnsAsync(matches);


            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("MatchId,HomeTeam,AwayTeam,Kickoff,HomeScore,AwayScore,Result,PenaltiesScore,Season,Competition,Stadium");

            foreach (var match in matches)
            {
                csvBuilder.AppendLine($"{match.Id},{match.HomeTeam},{match.AwayTeam},{match.Kickoff},{match.HomeScore},{match.AwayScore},{match.Result},{match.PenaltiesScore},{match.Season},{match.Competition},{match.Stadium}");
            }

            byte[] csvBytes = Encoding.UTF8.GetBytes(csvBuilder.ToString());

            //Act

            var result = await _controller.GetMatchesAsCsvFile(null, null, null, null, null);


            //Assert

            Assert.IsType<FileContentResult>(result);

            var fileResponse = (FileContentResult) result;

            Assert.NotNull(fileResponse);

            Assert.Equal(csvBytes, fileResponse.FileContents);

        }
    }
}
