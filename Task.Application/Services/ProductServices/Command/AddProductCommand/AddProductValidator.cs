using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.AddProductCommand
{
    public class AddProductValidator:AbstractValidator<AddProductRequest>
    {
        public AddProductValidator() {
            RuleFor(x=>x.Name).NotEmpty().NotNull()
                .WithMessage("Name Field not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
