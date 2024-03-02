using System;
using System.Collections.Generic;

namespace DerbyCountyAPI.Models;

public partial class UpcomingFixture
{
    public int Id { get; set; }

    public string? HomeTeam { get; set; }

    public string? AwayTeam { get; set; }

    public DateTime? Kickoff { get; set; }

    public string? Competition { get; set; }

    public string? Stadium { get; set; }

    public string? SkySportsUrl { get; set; }
}
