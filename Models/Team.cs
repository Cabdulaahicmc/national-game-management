using System.ComponentModel.DataAnnotations;

namespace national.Models
{
    public class Team
    {
     
            public int Id { get; set; } // Primary Key

            [Required]
            public string Name { get; set; }

            [Required]
            public string City { get; set; }

            [Required]
            public string Stadium { get; set; }

            [Required]
            public DateTime Founded { get; set; }

            // Navigation Properties
            public ICollection<Player> Players { get; set; }



    }
}
