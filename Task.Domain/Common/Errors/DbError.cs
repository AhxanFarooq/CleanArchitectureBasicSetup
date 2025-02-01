using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class DbError
        {
            public static Error UserCreationFailed(string msg) => Error.Validation(code: "User_Creation_Failed_Db", description: "Creation of user failed due to some reason." + msg);

        }
    }
}
