using WEBAPI_CommentManagementSystem.Business_Layer.Interfaces;
using WEBAPI_CommentManagementSystem.Business_Layer.Services.Repository;
using WEBAPI_CommentManagementSystem.Business_Layer.ViewModels;
using WEBAPI_CommentManagementSystem.Exceptions;
using WEBAPI_CommentManagementSystem.Models;

namespace WEBAPI_CommentManagementSystem.Business_Layer.Services
{
    public class CommentManagementService : ICommentManagementService
    {
        private readonly ICommentManagementRepository _repo;

        public CommentManagementService(ICommentManagementRepository repo)
        {
            _repo = repo;
        }

        public async Task<Comment> CreateComment(Comment employeeComment)
        {
            if (employeeComment == null || string.IsNullOrWhiteSpace(employeeComment.CommentText))
            {
                throw new InvalidModelException("Comment content is required.");
            }

            return await _repo.CreateComment(employeeComment);
        }

        public async Task<bool> DeleteCommentById(long id)
        {
            return await _repo.DeleteCommentById(id);
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _repo.GetAllComments();
        }

        public async Task<Comment> GetCommentById(long id)
        {
            return await _repo.GetCommentById(id);
        }

        public async Task<Comment> UpdateComment(CommentViewModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.CommentText))
            {
                throw new InvalidModelException("Updated comment content is required.");
            }

            return await _repo.UpdateComment(model);
        }
    }
}
