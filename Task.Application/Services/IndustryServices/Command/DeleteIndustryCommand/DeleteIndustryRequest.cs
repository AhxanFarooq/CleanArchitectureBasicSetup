using Application.Services.AreaServices.Command.DeleteAreaCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.DeleteIndustryCommand
{
    public record DeleteIndustryRequest : IRequest<DeleteIndustryResponse>
    {
        public Guid Id { get; set; }
    }
}
