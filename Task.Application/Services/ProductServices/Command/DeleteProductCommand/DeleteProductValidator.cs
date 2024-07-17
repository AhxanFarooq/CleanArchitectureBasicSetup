using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.DeleteProductCommand
{
    public class DeleteProductValidator:AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductValidator() {
            RuleFor(x=>x.Id).NotNull().NotEqual(Guid.Empty)
                .WithMessage("Id is not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
