using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace national.Models
{
    public class Player
    {
        public int Id { get; set; } // Primary Key

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Country { get; set; }

        // Foreign Key
        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; } // Navigation Property
    }
}
