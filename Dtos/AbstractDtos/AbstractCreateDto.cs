using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos.AbstractDtos
{
    public abstract class AbstractCreateDto
    {
        // Id created by Db, not needed

        [Required] // Cannot be null
        [MaxLength(50)]
        public string HowTo {get; set;}
        [Required]
        public string Line {get; set;}   
        [Required]
        public string Platform {get; set;}     
    }
}