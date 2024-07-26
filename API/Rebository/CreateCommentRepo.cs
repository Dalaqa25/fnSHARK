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

        public async Task<Comment?> DeleteAsync(int Id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == Id);

            if (commentModel == null)
            {
                return null;
            }

            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();

            return commentModel;
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

        public async Task<Comment?> UpdateAsync(int Id, UpdateCommentsDto updateCommentsDto)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == Id);

            if(commentModel == null)
            {
                return null;
            }

            commentModel.Tittle = updateCommentsDto.Tittle;
            commentModel.Content = updateCommentsDto.Content; 

            await _context.SaveChangesAsync();

            return commentModel;
        }
    }
}
