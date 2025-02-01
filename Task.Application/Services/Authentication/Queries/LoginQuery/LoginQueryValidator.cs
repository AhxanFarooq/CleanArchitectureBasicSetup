using AutoMapper;
using FluentValidation;
using System.Net;

namespace Application.Services.Authentication.Queries.LoginQuery
{
    public class LoginQueryValidator:AbstractValidator<LoginQueryRequest>
    {
        public LoginQueryValidator() {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email is required").WithErrorCode(HttpStatusCode.BadRequest.ToString())
                .EmailAddress().WithMessage("Received input is not email format").WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password is required").WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
