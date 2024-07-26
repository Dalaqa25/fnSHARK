using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateCommnetDto
    {
        [Required]
        [MinLength(3, ErrorMessage ="Title must be 3 charatres")]
        [MaxLength(15, ErrorMessage ="Title cannot be over 15 Charcters")]
        public string Tittle {get;set;} = String.Empty;

        [Required]
        [MinLength(3, ErrorMessage ="Content must be 3 charatres")]
        [MaxLength(280, ErrorMessage ="Content cannot be over 280 Charcters")]
        public string Content {get; set;} = string.Empty;
    }
}