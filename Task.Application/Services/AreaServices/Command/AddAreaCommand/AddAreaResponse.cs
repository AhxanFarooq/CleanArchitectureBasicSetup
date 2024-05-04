using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.AddAreaCommand
{
    public record AddAreaResponse
    {
        public Guid Id { get; set;}
        public string Message { get; set;}
    }
}
