using ErrorOr;

namespace CostCraft.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateUserName => Error.Conflict(
            code: "User.DuplicateUserName",
            description: "UserName already exists.");
    }
}
