using Application.Services.AreaServices.Command.AddAreaCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.AddQuotationCommand
{
    public class AddQuotationValidator : AbstractValidator<AddQuotationRequest>
    {
        public AddQuotationValidator()
        {
            RuleFor(x => x.Code).NotEmpty().NotNull()
                .WithMessage("Code Field not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());

            RuleFor(x => x.ContactId).NotEmpty().NotNull()
                .WithMessage("Contact not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());

        }
    }
}
