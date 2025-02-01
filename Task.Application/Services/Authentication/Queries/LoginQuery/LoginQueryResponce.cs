using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Queries.LoginQuery
{
    public record LoginQueryResponce
    {
        public string Token { get; set; } = string.Empty;
        public bool IsSuccess = false;
    }
}
