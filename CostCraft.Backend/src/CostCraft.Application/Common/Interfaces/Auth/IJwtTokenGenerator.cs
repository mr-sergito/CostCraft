using CostCraft.Domain.UserAggregate;

namespace CostCraft.Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
