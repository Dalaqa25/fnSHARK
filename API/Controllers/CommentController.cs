
using API.data;
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
        public CommentController(AppliactionDBcontext context,ICommentRepository comment)
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
    }

}
