
using API.models;

namespace API.Interface
{
    public interface ICommentRepository 
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<bool> StockExistsAsync(int StockId);
        Task<Comment> CreateAsync(Comment comment);
    }
}
