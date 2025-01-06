using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace national.Models
{
    public class Match
    {

        public int Id { get; set; } // Primary Key

        [Required]
        public DateTime MatchDate { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int DurationMinutes { get; set; }

        // Foreign Key for Team A
        public int TeamAId { get; set; }
        [ForeignKey("TeamAId")]
        public Team TeamA { get; set; } // Navigation Property

        // Foreign Key for Team B
        public int TeamBId { get; set; }
        [ForeignKey("TeamBId")]
        public Team TeamB { get; set; } // Navigation Property

        // Foreign Key for Game
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; } // Navigation Property


    }
}
