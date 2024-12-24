﻿namespace CostCraft.Application.Services.Authentication;

public record AuthenticationResult(
    Guid Id,
    string Username,
    string Token);
