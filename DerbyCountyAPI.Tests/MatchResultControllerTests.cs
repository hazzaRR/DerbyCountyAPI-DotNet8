using DerbyCountyAPI.Controllers;
using DerbyCountyAPI.Dto;
using DerbyCountyAPI.Interfaces;
using DerbyCountyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

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
                        Id = 1,
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
            //Arrage

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
    }
}
