using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.GetAreaQuery
{
    public record GetAreaRequest:IRequest<GetAreaResponse>
    {
        public Guid Id { get; set; }
    }
}
