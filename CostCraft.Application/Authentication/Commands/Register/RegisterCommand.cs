﻿using CostCraft.Application.Authentication.Common;
using CostCraft.Domain.UserAggregate.Enums;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string userName,
    string Password,
    Currency PreferredCurrency) : IRequest<ErrorOr<AuthenticationResult>>;
