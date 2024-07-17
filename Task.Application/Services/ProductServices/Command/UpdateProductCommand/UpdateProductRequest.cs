using Application.Services.ProductServices.Command.UpdateProductCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductServices.ProductServices.UpdateProductCommand
{
    public record UpdateProductRequest:IRequest<UpdateProductResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set;}
    }
}
