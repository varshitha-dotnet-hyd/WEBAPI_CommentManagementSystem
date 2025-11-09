using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPI_CommentManagementSystem.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Comment text is required")]
        [MinLength(5, ErrorMessage = "Comment text must be between 5 to 200 characters")]
        public string CommentText { get; set; }
        public int Rating { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
    }
}
