using Application.Services.AreaServices.Command.AddAreaCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.AddIndustryCommand
{
    public record AddIndustryRequest(string Name, string Description = "", bool IsActive = false) : IRequest<AddIndustryResponse>;
    
}
