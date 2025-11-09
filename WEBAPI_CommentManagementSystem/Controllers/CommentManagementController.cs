using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_CommentManagementSystem.Business_Layer.Interfaces;
using WEBAPI_CommentManagementSystem.Business_Layer.ViewModels;
using WEBAPI_CommentManagementSystem.Exceptions;
using WEBAPI_CommentManagementSystem.Models;

namespace WEBAPI_CommentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentManagementController : ControllerBase
    {
        private readonly ICommentManagementService _commentService;
        public CommentManagementController(ICommentManagementService commentservice)
        {
            _commentService = commentservice;
        }

        [HttpPost]
        [Route("create-comment")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateComment([FromBody] Comment model)
        {
            try
            {
                var result = await _commentService.CreateComment(model);
                return CreatedAtAction(nameof(GetCommentById), new { Id = model.CommentId }, model);
            }
            catch (InvalidModelException ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("update-comment")]
        public async Task<IActionResult> UpdateComment([FromBody] CommentViewModel model)
        {
            try
            {
                var comment = await _commentService.UpdateComment(model);
                return Ok(comment);
            }
            catch (CommentNotFoundException ex)
            {
                return NotFound(new Response { Status = "Error", Message = ex.Message });
            }
            catch (InvalidModelException ex)
            {
                return BadRequest(new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("delete-comment")]
        public async Task<IActionResult> DeleteComment(long id)
        {
            try
            {
                var result = await _commentService.DeleteCommentById(id);
                return Ok(result);
            }
            catch (CommentNotFoundException ex)
            {
                return NotFound(new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-comment-by-id")]
        public async Task<IActionResult> GetCommentById(long id)
        {
            try
            {
                var comment = await _commentService.GetCommentById(id);
                return Ok(comment);
            }
            catch (CommentNotFoundException ex)
            {
                return NotFound(new Response { Status = "Error", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("get-all-comments")]
        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _commentService.GetAllComments();
        }
    }
}
