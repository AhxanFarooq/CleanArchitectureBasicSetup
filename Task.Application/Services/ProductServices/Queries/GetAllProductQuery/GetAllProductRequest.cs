using Application.Services.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.GetAllProductQuery
{
    public record GetAllProductRequest:IRequest<PaginatedResponse<GetAllProductResponse>>
    {
        public string? Search { get; set; }
        public int PageIndex { get; set; }
        public int TotalSize { get; set; }
    }
}
