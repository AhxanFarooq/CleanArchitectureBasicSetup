using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Command.PatientCommand
{
    public class PatientCommandValidator:AbstractValidator<PatientCommandRequest>
    {
        public PatientCommandValidator() {
            RuleFor(x => x.Code).NotEmpty().NotNull().WithMessage("Code is required").WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("User name is required").WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
