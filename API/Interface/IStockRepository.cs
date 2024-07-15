
using API.models;

namespace API.Interface 
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
    }
    
}