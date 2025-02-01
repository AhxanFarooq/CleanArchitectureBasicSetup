using ErrorOr;

namespace Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error InvalidCredentials => Error.Validation(code: "invalid_email", description: "User provided email is not registered.");

            public static Error InvalidPassword => Error.Validation(code: "invalid_password", description: "User provided password is incorrect.");
        }
    }
}
