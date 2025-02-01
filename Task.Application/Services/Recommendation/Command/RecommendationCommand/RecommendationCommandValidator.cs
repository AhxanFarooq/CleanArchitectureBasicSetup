using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Command.RecommendationCommand
{
    public class RecommendationCommandValidator:AbstractValidator<RecommendationCommandRequest>
    {
        public RecommendationCommandValidator() {
            RuleFor(x => x.Type).NotEmpty().NotNull().WithMessage("Type is required").WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
