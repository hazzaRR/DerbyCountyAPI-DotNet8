﻿using DerbyCountyAPI.Interfaces;
using DerbyCountyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DerbyCountyAPI.Controllers
{
    [Route("api/fixture")]
    [ApiController]
    public class UpcomingFixtureController : ControllerBase
    {

        private readonly IUpcomingFixtureService _upcomingFixtureRepository;

        public UpcomingFixtureController(IUpcomingFixtureService upcomingFixtureRepository)
        {
            _upcomingFixtureRepository = upcomingFixtureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFixtures()
        {
            var fixtures = await _upcomingFixtureRepository.GetAllUpcomingFixtures();

            return Ok(fixtures);
        }


        [HttpGet("competitions")]
        public async Task<IActionResult> GetCompetitions()
        {
            var competitions = await _upcomingFixtureRepository.GetCompetitions();

            if (competitions == null)
            {
                return NotFound();
            }

            return Ok(competitions);
        }

        [HttpGet("find")]
        public async Task<IActionResult> GetFixturesByQuery([FromQuery] string? competition, [FromQuery] string? stadium, [FromQuery] string? team)
        {

            if (competition != null && stadium != null && team != null) 
            { 
                return Ok(await _upcomingFixtureRepository.GetFixturesByCompetitionAndStadiumAndTeam(competition, stadium, team));
            }
            else if (competition != null && team != null)
            {
                return Ok(await _upcomingFixtureRepository.GetFixturesByCompetitionAndTeam(competition, team));
            }
            else if (competition != null && stadium != null)
            {
                return Ok(await _upcomingFixtureRepository.GetFixturesByCompetitionAndStadium(competition, stadium));
            }
            else if (stadium != null && team != null)
            {
                return Ok(await _upcomingFixtureRepository.GetFixturesByStadiumAndTeam(stadium, team));
            }
            else if (stadium != null)
            {
                return Ok(await _upcomingFixtureRepository.GetFixturesByStadium(stadium));
            }
            else if (team != null)
            {
                return Ok(await _upcomingFixtureRepository.GetFixturesByTeam(team));
            }
            else if (competition != null)
            {
                return Ok(await _upcomingFixtureRepository.GetFixturesByCompetition(competition));
            }
            else
            {
                return Ok(await _upcomingFixtureRepository.GetAllUpcomingFixtures());
            }
        }
    }
}
