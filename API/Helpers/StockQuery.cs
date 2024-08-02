namespace API.Helpers
{
    public class StockQuery
    {
        public string? Symbol {get; set;} = null;
        public string? CompanyName {get; set;} = null;
        public int PageNumber {get; set;} = 1;
        public int PageSize {get; set;} = 20;
    }
}