using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.DeleteProductCommand
{
    public record DeleteProductResponse
    {
        public string Message { get; set; }
    }
}
