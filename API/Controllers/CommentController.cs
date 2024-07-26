
using API.data;
using API.Dtos;
using API.Interface;
using API.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("API/comment")]
    public class CommentController : ControllerBase
    {
        private readonly AppliactionDBcontext _context;
        private readonly ICommentRepository _commentrepo;
        public CommentController(AppliactionDBcontext context, ICommentRepository comment)
        {
            _context = context;
            _commentrepo = comment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commnet = await _commentrepo.GetAllAsync();

            var CommentsDto = commnet.Select(s => s.ToCommentDto());

            return Ok(CommentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var commnet = await _commentrepo.GetByIdAsync(id);

            if (commnet == null)
            {
                return NotFound();
            }

            return Ok(commnet.ToCommentDto());
        }

        [HttpPost("{StockId}")]
        public async Task<IActionResult> Create([FromRoute] int StockId, CreateCommnetDto commnetDto)
        {
            if (!await _commentrepo.StockExistsAsync(StockId))
            {
                return BadRequest("Not Found!");
            }

            var commentModel = commnetDto.ToCommetFromCreate(StockId);
            await _commentrepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, UpdateCommentsDto updateCommentsDto)
        {
            var commentModel = await _commentrepo.UpdateAsync(id,updateCommentsDto);

            if (commentModel == null)
            {
                return NotFound();
            }

            return Ok(commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var commentModel = await _commentrepo.DeleteAsync(id);

            if (commentModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
