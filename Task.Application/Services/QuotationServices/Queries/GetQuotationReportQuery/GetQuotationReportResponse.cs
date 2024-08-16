
using Application.Services.QuotationServices.Queries.GetQuotationReportQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuotationServices.Command.GetQuotationReportQuery
{
    public record GetQuotationReportResponse
    {
        public string TodayDate { get; set; }
        public string CompanyTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Attention { get; set; }
        public string Subject { get; set; }
        public string Greeting { get; set; }
        public string Addressing { get; set; }
        public string Price { get; set; }
        public string ProductName { get; set; }
        public string TermAndCondition { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public bool IsMultipleItem { get; set; }
        public ICollection<QuotationReportItemModel> QuotationReportItemModels { get; set; }
    }
}
