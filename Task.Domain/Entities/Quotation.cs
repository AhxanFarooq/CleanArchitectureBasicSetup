using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Quotation:BaseEntity
    {
        public string Code { get; set; }
        public Guid ContactId { get; set; }
        public virtual Contact Contact { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal SaleTax { get; set; }
        public decimal NetAmount { get; set; }
        public string TermAndCondition { get; set; }
        public string OverallDiscSign { get; set; }
        public string TaxSign { get; set; }
        public virtual ICollection<QuotationItem> QuotationItems { get; set; }
    }
}
