using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.Queries.SignInUser
{
    public record SignInUserResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public object Token { get; set; }
        public string Message { get; set; }
    }
}
