using DerbyCountyAPI.Controllers;
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

    }
}
