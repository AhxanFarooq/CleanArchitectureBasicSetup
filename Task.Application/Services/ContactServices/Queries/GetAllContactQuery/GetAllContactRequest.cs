using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.GetAllContactQuery
{
    public record GetAllContactRequest:IRequest<List<GetAllContactResponse>>
    {
        
    }
}
