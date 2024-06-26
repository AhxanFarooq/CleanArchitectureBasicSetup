﻿using Application.Services.AreaServices.Command.GetAreaQuery;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.GetIndustryQuery
{
    public class GetIndustryValidator : AbstractValidator<GetIndustryRequest>
    {
        public GetIndustryValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEqual(Guid.Empty)
                .WithMessage("Id is not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
