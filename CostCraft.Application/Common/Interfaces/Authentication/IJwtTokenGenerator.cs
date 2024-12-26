using CostCraft.Domain.Entities;

namespace CostCraft.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
