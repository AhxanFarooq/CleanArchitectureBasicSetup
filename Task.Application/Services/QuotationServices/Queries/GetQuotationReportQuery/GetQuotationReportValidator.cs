using Application.Services.AreaServices.Command.GetAreaQuery;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuotationServices.Command.GetQuotationReportQuery
{
    public class GetQuotationReportValidator : AbstractValidator<GetQuotationReportRequest>
    {
        public GetQuotationReportValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEqual(Guid.Empty)
                .WithMessage("Id is not empty")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
