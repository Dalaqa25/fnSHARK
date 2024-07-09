using API.Dtos;
using API.models;

namespace API.Mapper
{
    public static class StockMapper
    {
       public static StockDto ToStockDto(this Stock stockModel)
       {
            return new StockDto
            {
              Id = stockModel.Id,
              Symbol = stockModel.Symbol,
              CompanyName = stockModel.CompanyName,
              Purchase = stockModel.Purchase,
              LastDiv = stockModel.LastDiv,
              Industry = stockModel.Industry,
              MarketCap = stockModel.MarketCap,
            };
       } 
    }   
}


