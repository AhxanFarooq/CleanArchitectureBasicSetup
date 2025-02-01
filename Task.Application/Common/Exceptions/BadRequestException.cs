

namespace Application.Common.Exceptions
{
    public class BadRequestException:Exception
    {
        public string[] Error { get; set; } = new string[0];
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message,Exception exception) : base(message, exception) { }
        public BadRequestException(string[] errors)
        {
            Error = errors;
        }
    }
}
