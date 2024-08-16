using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuotationServices.Command.GetQuotationReportQuery
{
    public record GetQuotationReportRequest:IRequest<GetQuotationReportResponse>
    {
        public Guid Id { get; set; }
        public string ParentPath { get; set; }
    }
}
