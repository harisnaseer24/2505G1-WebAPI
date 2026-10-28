using System.ComponentModel.DataAnnotations;

namespace _2505g1_web_api.Models.DTOs
{
    public class TeamDTO
    {
       
        public string TeamName { get; set; } = null!;

        public string Slogan { get; set; } = null!;

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Draw { get; set; }
    }
}
