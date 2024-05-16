using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.AddAreaCommand
{
    public class AddAreaValidator:AbstractValidator<AddAreaRequest>
    {
        public AddAreaValidator() {
            RuleFor(x=>x.Name).NotEmpty().NotNull()
                .WithMessage("Name Field not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
