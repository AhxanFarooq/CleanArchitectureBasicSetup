using Application.Services.AreaServices.Command.AddQuotationCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.UpdateQuotationCommand
{
    public class UpdateQuotationValidator : AbstractValidator<UpdateQuotationRequest>
    {
        public UpdateQuotationValidator()
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
