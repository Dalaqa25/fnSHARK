

using API.Interface;
using API.models;
using API.data;
using Microsoft.EntityFrameworkCore;
using API.Dtos.Stock;

namespace API.Rebository
{
    public class CreateStockRepo : IStockRepository
    {
        private readonly AppliactionDBcontext _context;
        public CreateStockRepo(AppliactionDBcontext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockmodel)
        {
            await _context.Stock.AddAsync(stockmodel);
            await _context.SaveChangesAsync();
            return stockmodel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null)
            {
                return null; 
            }

            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stock.Include(c => c.Commnet).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stock.Include(c => c.Commnet).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockRequestDto)
        {
            var excistingStock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);

            if (excistingStock == null)
            {
                return null;
            }

            excistingStock.Symbol = stockRequestDto.Symbol;
            excistingStock.CompanyName = stockRequestDto.CompanyName;
            excistingStock.Purchase = stockRequestDto.Purchase;
            excistingStock.LastDiv = stockRequestDto.LastDiv;
            excistingStock.Industry = stockRequestDto.Industry;
            excistingStock.MarketCap = stockRequestDto.MarketCap;

            await _context.SaveChangesAsync();

            return excistingStock;
        }
    }

}
