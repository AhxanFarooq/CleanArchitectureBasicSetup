using Application.Services.AreaServices.Command.DeleteAreaCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.DeleteContactCommand
{
    public class DeleteContactValidator : AbstractValidator<DeleteContactRequest>
    {
        public DeleteContactValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEqual(Guid.Empty)
                .WithMessage("Id is not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
