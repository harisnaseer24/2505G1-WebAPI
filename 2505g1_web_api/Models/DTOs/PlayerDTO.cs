using System.ComponentModel.DataAnnotations;

namespace _2505g1_web_api.Models.DTOs
{
    public class PlayerDTO
    {

        public string Name { get; set; } = null!;

        public string Style { get; set; } = null!;

        public string Type { get; set; } = null!;

        public int Runs { get; set; }

        public double StrikeRate { get; set; }

        public double Average { get; set; }

        public int TeamId { get; set; }
    }
}
