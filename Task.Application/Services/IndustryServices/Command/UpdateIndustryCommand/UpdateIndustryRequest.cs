using Application.Services.AreaServices.Command.UpdateAreaCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.UpdateIndustryCommand
{
    public record UpdateIndustryRequest : IRequest<UpdateIndustryResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
