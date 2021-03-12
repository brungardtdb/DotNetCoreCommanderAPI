using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Command
    {
        [Key] // Key for DB table
        public int Id {get; set;}
        
        [Required] // Cannot be null
        [MaxLength(50)] // We can also limit characters
        public string HowTo {get; set;}

        [Required]
        public string Line {get; set;}

        [Required]
        public string Platform {get; set;}
    }
}