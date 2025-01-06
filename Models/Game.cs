using System.ComponentModel.DataAnnotations;

namespace national.Models
{
    public class Game
    {
        
            public int Id { get; set; } // Primary Key

            [Required]
            public string Name { get; set; }

            public string Description { get; set; }

            [Required]
            public DateTime GameDate { get; set; }

            [Required]
            public string Location { get; set; }

        // Navigation Properties
        public ICollection<Match> Matches { get; set; }



    }
}
