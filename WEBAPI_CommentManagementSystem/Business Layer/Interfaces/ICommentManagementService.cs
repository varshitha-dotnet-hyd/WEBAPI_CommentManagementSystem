using WEBAPI_CommentManagementSystem.Business_Layer.ViewModels;
using WEBAPI_CommentManagementSystem.Models;

namespace WEBAPI_CommentManagementSystem.Business_Layer.Interfaces
{
    public interface ICommentManagementService
    {
        Task<List<Comment>> GetAllComments();
        Task<Comment> CreateComment(Comment comment);
        Task<Comment> GetCommentById(long id);
        Task<bool> DeleteCommentById(long id);
        Task<Comment> UpdateComment(CommentViewModel model);
    }
}
