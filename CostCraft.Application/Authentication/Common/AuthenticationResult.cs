﻿using CostCraft.Domain.User;

namespace CostCraft.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);
