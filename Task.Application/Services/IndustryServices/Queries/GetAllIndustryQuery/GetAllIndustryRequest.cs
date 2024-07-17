using Application.Services.AreaServices.Command.GetAllAreaQuery;
using Application.Services.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.GetAllIndustryQuery
{
    public record GetAllIndustryRequest : IRequest<PaginatedResponse<GetAllIndustryResponse>>
    {
        public string? Search { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
