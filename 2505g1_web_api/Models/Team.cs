using System;
using System.Collections.Generic;

namespace _2505g1_web_api.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string Slogan { get; set; } = null!;

    public int Wins { get; set; }

    public int Losses { get; set; }

    public int Draw { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
