
using System.ComponentModel.DataAnnotations.Schema;

namespace API.models
{
    public class Stock
    {
        public int Id {get; set;}
        public string Symbol {get; set;} = string.Empty;
        public string CompanyName {get; set;} = string.Empty;
        [Column(TypeName ="decimal(18,2)")]
        public decimal Purchase {get;set;}
        [Column(TypeName ="decimal(18,2)")]
        public decimal LastDiv {get;set;}
        public string Industry {get;set;} = string.Empty;
        public long MarketCap {get;set;}
        
        //navigation between models
         public List<Comment> Commnet { get; set; } = new List<Comment>();

    }
}