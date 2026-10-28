using System;
using System.Collections.Generic;

namespace _2505g1_web_api.Models;

public partial class Player
{
    public int PlayerId { get; set; }

    public string Name { get; set; } = null!;

    public string Style { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Runs { get; set; }

    public double StrikeRate { get; set; }

    public double Average { get; set; }

    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;
}
