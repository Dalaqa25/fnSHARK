using API.Dtos;
using API.models;

namespace API.Mapper
{
    public static class CommentMapper
    {
        public static CommentsDto ToCommentDto(this Comment commentModel)
        {
            return new CommentsDto
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                Tittle = commentModel.Tittle,
                StockId = commentModel.StockId
            };
        }
    }
}
