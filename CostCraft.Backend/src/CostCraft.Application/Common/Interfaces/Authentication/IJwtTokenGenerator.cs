using CostCraft.Domain.UserAggregate;

namespace CostCraft.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
