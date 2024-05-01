

namespace Application.Common.Exceptions
{
    public class BadRequestException:Exception
    {
        public string[] Error { get; set; }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string[] errors)
        {
            Error = errors;
        }
    }
}
