
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stocks = await _stockrepo.GetAllAsync();
            var stockDtos = stocks.Select(s => s.ToStockDto());

            return Ok(stocks);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var stockModel = stockDto.ToStockFromCreateDTO();
            await _stockrepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           var stockModel = await _stockrepo.UpdateAsync(id, updateDto);

           if(stockModel == null)
           {
                return NotFound();
           }
        
            return Ok(stockModel.ToStockDto());
        }



        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            var stockModel = await _stockrepo.DeleteAsync(id);

            if(stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
