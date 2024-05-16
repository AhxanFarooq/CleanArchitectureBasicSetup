using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.GetContactQuery
{
    public record GetContactRequest:IRequest<GetContactResponse>
    {
        public Guid Id { get; set; }
    }
}
