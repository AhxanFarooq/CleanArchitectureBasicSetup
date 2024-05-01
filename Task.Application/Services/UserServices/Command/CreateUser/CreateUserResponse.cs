

namespace Application.Services.UserServices.Command.CreateUser
{
    public sealed record CreateUserResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }
}
