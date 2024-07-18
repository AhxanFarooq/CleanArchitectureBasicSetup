using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuotationServices.Command.AddQuotationCommand
{
    public record QuotationItemModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid QuotationId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal LineTotal { get; set; }
    }
}
