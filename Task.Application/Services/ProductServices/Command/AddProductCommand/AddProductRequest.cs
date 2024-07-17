using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.AddProductCommand
{
    public record AddProductRequest(string Name,int SalePrice,int RetailPrice, string Description = "", bool IsActive = false):IRequest<AddProductResponse>;
}
