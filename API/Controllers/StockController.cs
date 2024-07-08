
using API.data;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("API/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly AppliactionDBcontext _context;

        public StockController(AppliactionDBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stock.ToList()
            .Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stock.Find(id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

    }
}
