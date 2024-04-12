using System;
using System.Collections.Generic;

namespace DerbyCountyAPI.Models;

public partial class MatchResult
{
    public int Id { get; set; }

    public string? HomeTeam { get; set; }

    public string? AwayTeam { get; set; }

    public DateTime? Kickoff { get; set; }

    public string? Competition { get; set; }

    public string? Stadium { get; set; }

    public int? HomeScore { get; set; }

    public int? AwayScore { get; set; }

    public string? Result { get; set; }

    public string? Season { get; set; }

    public string? PenaltiesScore { get; set; }
}
