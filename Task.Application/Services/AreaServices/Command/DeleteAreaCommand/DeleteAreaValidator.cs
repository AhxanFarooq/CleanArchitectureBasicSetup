using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.DeleteAreaCommand
{
    public class DeleteAreaValidator:AbstractValidator<DeleteAreaRequest>
    {
        public DeleteAreaValidator() {
            RuleFor(x=>x.Id).NotNull().NotEqual(Guid.Empty)
                .WithMessage("Id is not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
