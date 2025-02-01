using ErrorOr;

namespace Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error DuplicateEmail => Error.Conflict(code: "duplicate_email", description: "User provided email is already exist");
        }
    }
}
