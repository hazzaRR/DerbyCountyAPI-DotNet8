using System;
using System.Collections.Generic;

namespace DerbyCountyAPI.Models;

public partial class LeagueTable
{
    public string Team { get; set; } = null!;

    public int? LeaguePosition { get; set; }

    public int? GamesPlayed { get; set; }

    public int? Wins { get; set; }

    public int? Draws { get; set; }

    public int? Losses { get; set; }

    public int? GoalsFor { get; set; }

    public int? GoalsAgainst { get; set; }

    public int? GoalDifference { get; set; }

    public int? Points { get; set; }
}
