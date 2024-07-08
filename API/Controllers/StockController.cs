
using API.data;
using API.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

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
            var stocks = _context.Stock.ToList();

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

            return Ok(stock);
        }

    }
}
