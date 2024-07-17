using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.GetAllProductQuery
{
    public record GetAllProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
