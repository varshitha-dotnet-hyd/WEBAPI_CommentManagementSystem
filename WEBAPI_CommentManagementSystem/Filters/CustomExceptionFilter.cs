using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WEBAPI_CommentManagementSystem.Exceptions;
using WEBAPI_CommentManagementSystem.Models;

namespace WEBAPI_CommentManagementSystem.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var response = new Response
            {
                Status = "Error",
                Message = context.Exception.Message
            };

            switch (context.Exception)
            {
                case CommentNotFoundException:
                    context.Result = new NotFoundObjectResult(response);
                    break;

                case InvalidModelException:
                    context.Result = new BadRequestObjectResult(response);
                    break;

                default:
                    context.Result = new ObjectResult(response)
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                    break;
            }

            context.ExceptionHandled = true;
        }
    }
}
