using Microsoft.EntityFrameworkCore;
using WEBAPI_CommentManagementSystem.Models;

namespace WEBAPI_CommentManagementSystem.Data
{
    public class CommentManagementAppDbContext : DbContext
    {
        public CommentManagementAppDbContext(DbContextOptions<CommentManagementAppDbContext> options) : base(options)
        {
        }
        public DbSet<Comment> Comments { get; set; }
    }
}
