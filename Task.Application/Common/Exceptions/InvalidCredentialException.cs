using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class InvalidCredentialException:Exception
    {
        public InvalidCredentialException() { }
        public InvalidCredentialException(string message) : base(message)
        {
        }

        public InvalidCredentialException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
