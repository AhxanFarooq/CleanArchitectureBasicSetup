using Application.Services.AreaServices.Command.AddAreaCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.AddContactCommand
{
    public class AddContactValidator : AbstractValidator<AddContactRequest>
    {
        public AddContactValidator()
        {
            RuleFor(x => x.CompanyTitle).NotEmpty().NotNull()
                .WithMessage("Title Field not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());

            RuleFor(x => x.AreaId).NotEmpty().NotNull()
                .WithMessage("Area not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());

            RuleFor(x => x.IndustryId).NotEmpty().NotNull()
                .WithMessage("Industry not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
