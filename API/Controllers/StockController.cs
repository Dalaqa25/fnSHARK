
using API.data;
using API.Mapper;
using API.Dtos;
using API.Dtos.Stock;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.models;


namespace API.Controllers
{
    [Route("API/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly AppliactionDBcontext _context;
        private readonly IStockRepository _stockrepo;
        public StockController(AppliactionDBcontext context, IStockRepository stockrepo)
        {
            _context = context;
            _stockrepo = stockrepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockrepo.GetAllAsync();
            var stockDtos = stocks.Select(s => s.ToStockDto());

            return Ok(stocks);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _context.Stock.FindAsync(id);    

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateStockRequestDto updateDto)
        {
           var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);

           if(stockModel == null)
           {
                return NotFound();
           }
        

            stockModel.Symbol = updateDto.Symbol;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.Industry = updateDto.Industry;
            stockModel.MarketCap = updateDto.MarketCap;

           await _context.SaveChangesAsync();

            return Ok(stockModel.ToStockDto());
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null)
            {
                return NotFound();
            }

            _context.Stock.Remove(stockModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
