﻿using ErrorOr;

namespace CostCraft.Domain.Common.Errors;

public static partial class Errors
{
    public static class Auth
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid credentials.");
    }
}
