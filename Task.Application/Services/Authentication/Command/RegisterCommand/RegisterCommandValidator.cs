using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Command.RegisterCommand
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator() {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email is required").WithErrorCode(HttpStatusCode.BadRequest.ToString())
                .EmailAddress().WithMessage("Received input is not email format").WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password is required").WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("User name is required").WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(x => x.User_Role).NotEmpty().NotNull().WithMessage("User role is required").WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
