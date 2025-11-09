using Microsoft.EntityFrameworkCore;
using WEBAPI_CommentManagementSystem.Business_Layer.ViewModels;
using WEBAPI_CommentManagementSystem.Data;
using WEBAPI_CommentManagementSystem.Exceptions;
using WEBAPI_CommentManagementSystem.Models;

namespace WEBAPI_CommentManagementSystem.Business_Layer.Services.Repository
{
    public class CommentManagementRepository : ICommentManagementRepository
    {
        private readonly CommentManagementAppDbContext _dbContext;
        public CommentManagementRepository(CommentManagementAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> CreateComment(Comment CommentModel)
        {
            if (string.IsNullOrWhiteSpace(CommentModel.CommentText))
            {
                throw new InvalidModelException("Comment Text cannot be empty.");
            }

            await _dbContext.Comments.AddAsync(CommentModel);
            await _dbContext.SaveChangesAsync();
            return CommentModel;
        }

        public async Task<bool> DeleteCommentById(long id)
        {
            Comment comment = await GetCommentById(id);
            if (comment == null)
            {
                throw new CommentNotFoundException($"Comment with ID {id} not found.");
            }

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment> GetCommentById(long id)
        {
            var comment = await _dbContext.Comments.AsNoTracking().FirstOrDefaultAsync(c => c.CommentId == id);
            if (comment == null)
            {
                throw new CommentNotFoundException($"Comment with ID {id} not found.");
            }
            return comment;
        }

        public async Task<Comment> UpdateComment(CommentViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.CommentText))
            {
                throw new InvalidModelException("Updated comment Text cannot be empty.");
            }

            Comment comment = await GetCommentById(model.CommentId);
            if (comment == null)
            {
                throw new CommentNotFoundException($"Comment with ID {model.CommentId} not found.");
            }

            comment.CommentText = model.CommentText;
            comment.SubmissionDate = DateTime.Now;

            _dbContext.Comments.Update(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }
    }
}
