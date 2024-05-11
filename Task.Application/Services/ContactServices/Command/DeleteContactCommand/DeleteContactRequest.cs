using Application.Services.AreaServices.Command.DeleteAreaCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.DeleteContactCommand
{
    public record DeleteContactRequest : IRequest<DeleteContactResponse>
    {
        public Guid Id { get; set; }
    }
}
