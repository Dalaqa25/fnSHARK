using API.Interface;
using API.data;
using Microsoft.EntityFrameworkCore;
using API.models;

namespace API.Repository
{
    public class CreateCommentRepo : ICommentRepository
    {
        private readonly AppliactionDBcontext _context;
        public CreateCommentRepo(AppliactionDBcontext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
