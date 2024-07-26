
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateStockDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symobls Cannot be more then 10")]
        public string Symbol {get; set;} = string.Empty;

        [Required]
        [MaxLength(10, ErrorMessage = "Comapany Name Cannot be more then 10")]
        public string CompanyName {get; set;} = string.Empty;

        [Required]
        [Range(1, 1000000)]
        public decimal Purchase {get;set;}

        
        [Required]
        [Range(0.01, 100)]
        public decimal LastDiv {get;set;}

        [Required]
        [MaxLength(10, ErrorMessage = "Comapany Name Cannot be more then 10")]
        public string Industry {get;set;} = string.Empty;

        [Required]
        [Range(1,5000000)]
        public long MarketCap {get;set;}
    }

}
