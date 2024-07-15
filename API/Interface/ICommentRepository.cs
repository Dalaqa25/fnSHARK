
using API.models;

namespace API.Interface
{
    public interface ICommentRepository 
    {
        Task<List<Comment>> GetAllAsync();
    }

}
