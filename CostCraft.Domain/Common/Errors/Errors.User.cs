using ErrorOr;

namespace CostCraft.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateUsername => Error.Conflict(
            code: "User.DuplicateUsername",
            description: "Username already exists.");
    }
}
