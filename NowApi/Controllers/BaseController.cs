using Application.Services.Authentication.Queries.LoginQuery;
using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace NowApi.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count == 0)
            {
                return Problem();
            }
            if (errors.All(e => e.Type == ErrorType.Validation))
            {

                return ValidationProblem(errors);
            }
            var firstError = errors.FirstOrDefault();
            return Problem(firstError);
        }

        protected IActionResult ValidationProblem(List<Error> errors)
        {
            var errorDictionary = errors
                .GroupBy(e => e.Code, e => e.Description)
                .ToDictionary(g => g.Key, g => g.ToArray());

            // Return a validation problem response with the grouped errors
            return new BadRequestObjectResult(new
            {
                errors = errorDictionary
            });
        }
        protected IActionResult Problem(Error error)
        {

            var statusCode = error.Type switch
            {
                ErrorType.Validation => (int)HttpStatusCode.BadRequest,
                ErrorType.Conflict => (int)HttpStatusCode.Conflict,
                ErrorType.NotFound => (int)HttpStatusCode.NotFound,
                ErrorType.Unauthorized => (int)HttpStatusCode.Unauthorized,
                ErrorType.Forbidden => (int)HttpStatusCode.Forbidden,
                _ => (int)HttpStatusCode.InternalServerError
            };
            return new ObjectResult(new
            {
                error = error.Description // Only return the error message
            })
            {
                StatusCode = statusCode
            };
        }

        protected IActionResult SaveTokenToCockies(LoginQueryResponce responce)
        {

            CookieOptions options = new()
            {
                Expires = DateTimeOffset.Now.AddSeconds(responce.ExpiryTime),
                HttpOnly = true,
                Path = "/",
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
                Secure = true
            };

            // Append the token to the response cookies
            Response.Cookies.Append("session-id", responce.Token, options);

            // Add Partitioned attribute to the Set-Cookie header
            string setCookieHeader = Response.Headers["Set-Cookie"];
            if (!string.IsNullOrEmpty(setCookieHeader))
            {
                setCookieHeader += "; Partitioned";
                Response.Headers["Set-Cookie"] = setCookieHeader;
            }

            return Ok(new { responce.ExpiryTime });
        }
    }
}
