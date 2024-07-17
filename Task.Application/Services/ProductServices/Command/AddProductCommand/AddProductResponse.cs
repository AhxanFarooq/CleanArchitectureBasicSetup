using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.AddProductCommand
{
    public record AddProductResponse
    {
        public Guid Id { get; set;}
        public string Message { get; set;}
    }
}
