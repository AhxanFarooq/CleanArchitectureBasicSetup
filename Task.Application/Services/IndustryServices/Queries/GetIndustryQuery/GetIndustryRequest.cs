using Application.Services.AreaServices.Command.GetAreaQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.GetIndustryQuery
{
    public record GetIndustryRequest : IRequest<GetIndustryResponse>
    {
        public Guid Id { get; set; }
    }
}
