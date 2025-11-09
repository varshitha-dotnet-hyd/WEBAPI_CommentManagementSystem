using System.ComponentModel.DataAnnotations;

namespace WEBAPI_CommentManagementSystem.Business_Layer.ViewModels
{
    public class CommentViewModel
    {
        [Required(ErrorMessage = "Comment Id is required")]
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
