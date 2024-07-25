using API.Interface;
using API.data;
using Microsoft.EntityFrameworkCore;
using API.models;
using Microsoft.AspNetCore.Http.HttpResults;
using API.Mapper;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Repository
{
    public class CreateCommentRepo : ICommentRepository
    {
        private readonly AppliactionDBcontext _context;
        public CreateCommentRepo(AppliactionDBcontext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<bool> StockExistsAsync(int StockId)
        {
            return await _context.Stock.AnyAsync(x => x.Id == StockId);
        }
    }
}
