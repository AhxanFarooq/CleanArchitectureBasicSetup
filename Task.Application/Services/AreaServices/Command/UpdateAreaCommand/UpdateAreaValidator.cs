using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.UpdateAreaCommand
{
    public class UpdateAreaValidator:AbstractValidator<UpdateAreaRequest>
    {
        public UpdateAreaValidator() {
            RuleFor(x => x.Id).NotNull().NotEqual(Guid.Empty)
                .WithMessage("Id is not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
            RuleFor(x => x.Name).NotEmpty().NotNull()
                .WithMessage("Name Field not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
