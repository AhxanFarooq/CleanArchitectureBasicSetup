using Application.Services.AreaServices.Command.GetAllAreaQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.GetAllIndustryQuery
{
    public record GetAllIndustryRequest : IRequest<List<GetAllIndustryResponse>>
    {
        public string? Search { get; set; }
    }
}
