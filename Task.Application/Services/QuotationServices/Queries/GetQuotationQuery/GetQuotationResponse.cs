using Application.Services.QuotationServices.Command.AddQuotationCommand;
using Application.Services.QuotationServices.Command.AddQuotationCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.GetQuotationQuery
{
    public record GetQuotationResponse
    {
        public string Code { get; set; }
        public Guid ContactId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal SaleTax { get; set; }
        public decimal NetAmount { get; set; }
        public string TermAndCondition { get; set; }
        public virtual ICollection<QuotationItemModel> QuotationItemModels { get; set; }
    }
}
