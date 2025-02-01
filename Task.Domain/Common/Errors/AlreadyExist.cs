using ErrorOr;

namespace Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class AlreadyExist
        {
            public static Error RecordExist => Error.Conflict(code: "already_exist", description: "Record already exist");
        }
    }
}
