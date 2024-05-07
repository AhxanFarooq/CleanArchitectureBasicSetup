using Application.Services.AreaServices.Command.AddAreaCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.AddIndustryCommand
{
    public class AddIndustryValidator : AbstractValidator<AddIndustryRequest>
    {
        public AddIndustryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("Name Field not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
