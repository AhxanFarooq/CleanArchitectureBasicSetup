using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Common
{
    public record BaseRequest
    {
        public Guid Id { get; set; }
    }
}
