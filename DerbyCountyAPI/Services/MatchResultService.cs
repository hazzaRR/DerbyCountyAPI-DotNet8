﻿using DerbyCountyAPI.Models;
using DerbyCountyAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using DerbyCountyAPI.Dto;

namespace DerbyCountyAPI.Services
{
    public class MatchResultService : IMatchResultService
    {

        private readonly DerbycountyContext _context;

        public MatchResultService(DerbycountyContext context)
        {
            _context = context;
        }

        public async Task<List<MatchResult>> GetAllMatchResults()
        {
            return await _context.MatchResults.ToListAsync();
        }

        public async Task<List<string?>> GetCompetitionsPlayedIn(string? season, string? team)
        {
            var query = _context.MatchResults.AsQueryable();

            if (season != null)
            {
                query = query.Where(match => match.Season == season);
            }

            if (team != null)
            {
                query = query.Where(match => match.HomeTeam == team || match.AwayTeam == team);
            }

            var competitions = await query
                .Select(match => match.Competition)
                .Distinct()
                .ToListAsync();

            return competitions;
        }

        public async Task<string?> GetCurrentSeason()
        {
            return await _context.MatchResults.Select(match => match.Season).OrderByDescending(season => season).FirstOrDefaultAsync();
        }

        public async Task<MatchResult?> GetLatestMatchResult()
        {
            return await _context.MatchResults.OrderByDescending(match => match.Kickoff).FirstOrDefaultAsync();
        }

        public async Task<MatchResult?> GetMatchResultById(int id)
        {
            return await _context.MatchResults.FirstOrDefaultAsync(match => match.Id == id);
        }

        public async Task<List<MatchResult>> GetMatchResultsByQuery(string? season, string? competition, string? stadium, string? team, string? result)
        {
            var query = _context.MatchResults.OrderByDescending(match => match.Kickoff).AsQueryable();

            if (season != null)
            {
                query = query.Where(match => match.Season == season);
            }
            if (competition != null)
            {
                query = query.Where(match => match.Competition == competition);
            }
            if (stadium != null)
            {
                query = query.Where(match => match.Stadium == stadium);
            }
            if (team != null)
            {
                query = query.Where(match => match.HomeTeam == team || match.AwayTeam == team);
            }
            if (result != null)
            {
                query = query.Where(match => match.Result == result);
            }

            var matches = await query.ToListAsync();

            return matches;
        }

        public async Task<PagedResponseDTO<MatchResult>> GetMatchResultsByQueryWithPagination(int pageNumber, int pageSize, string? season, string? competition, string? stadium, string? team, string? result)
        {
            var query = _context.MatchResults.OrderByDescending(match => match.Kickoff).AsQueryable();

            if (season != null)
            {
                query = query.Where(match => match.Season == season);
            }
            if (competition != null)
            {
                query = query.Where(match => match.Competition == competition);
            }
            if (stadium != null)
            {
                query = query.Where(match => match.Stadium == stadium);
            }
            if (team != null)
            {
                query = query.Where(match => match.HomeTeam == team || match.AwayTeam == team);
            }
            if (result != null)
            {
                query = query.Where(match => match.Result == result);
            }


            var totalRecords = query.Count();

            var matches = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();


            PagedResponseDTO<MatchResult> pagedResponse = new(pageNumber, pageSize, totalRecords, matches);

            return pagedResponse;
        }

        public async Task<List<RecordDTO>> GetRecord(string? team)
        {
            var query = _context.MatchResults.AsQueryable();


            if (team != null)
            {
                query = query.Where(match => match.HomeTeam == team || match.AwayTeam == team);
            }

            return await query
            .GroupBy(match => match.Result)
            .Select(match => new RecordDTO { Result = match.Key, Count = match.Count() })
            .ToListAsync();

        }


        public async Task<List<string?>> GetSeasonsPlayedIn()
        {
            return await _context.MatchResults.Select(match => match.Season).Distinct().OrderByDescending(match => match).ToListAsync();
        }

        public async Task<List<string?>> GetTeamsPlayedAgainst(string? season, string? competition)
        {
            var query = _context.MatchResults.AsQueryable();

            if (season != null)
            {
                query = query.Where(match => match.Season == season);
            }
            if (competition != null)
            {
                query = query.Where(match => match.Competition == competition);
            }

            var teams = await query
                .Where(match => match.HomeTeam != "Derby County")
                .Select(match => match.HomeTeam)
                .Union(
                query
                .Where(match => match.AwayTeam != "Derby County")
                .Select(match => match.AwayTeam)
                )
                .Distinct()
                .OrderBy(match => match)
                .ToListAsync();

            return teams;
        }

    }
}
