
using API.Dtos.Stock;
using API.models;

namespace API.Interface 
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockmodel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockRequestDto);
        Task<Stock?> DeleteAsync(int id);
    }
    
}