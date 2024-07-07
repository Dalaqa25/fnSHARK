
namespace API.models
{
    public class Comment
    {
        public int Id {get;set;}
        public string Tittle {get;set;} = String.Empty;
        public string Content {get; set;} = string.Empty;
        public DateTime CreatedOn {get; set;} = DateTime.Now;
        public int? StockId { get; set; }
        //Navigation
        public Stock? Stock {get; set;}
    }
}