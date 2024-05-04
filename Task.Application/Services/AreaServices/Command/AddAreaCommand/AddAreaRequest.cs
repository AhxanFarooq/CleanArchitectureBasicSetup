using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.AddAreaCommand
{
    public record AddAreaRequest(string Name, string Description = "", bool IsActive = false):IRequest<AddAreaResponse>;
}
