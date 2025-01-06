using System.ComponentModel.DataAnnotations;

namespace national.Models
{
    public class Coach
    {
     
            public int Id { get; set; } // Primary Key

            [Required]
            public string Name { get; set; }

            [Required]
            public int ExperienceYears { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string Phone { get; set; }

            // Navigation Properties
            public ICollection<Team> Teams { get; set; } // One-to-Many with Team
      

    }
}
