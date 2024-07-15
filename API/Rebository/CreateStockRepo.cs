

using API.Interface;
using API.models;
using API.data;
using Microsoft.EntityFrameworkCore;

namespace API.Rebository
{
    public class CreateStockRepo : IStockRepository
    {
        private readonly AppliactionDBcontext _context;
        public CreateStockRepo(AppliactionDBcontext context)
        {
            _context = context;
        }
        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stock.ToListAsync();

        }
    }

}
