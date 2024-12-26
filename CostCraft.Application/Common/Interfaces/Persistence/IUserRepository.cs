using CostCraft.Domain.Entities;

namespace CostCraft.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserById(Guid id);
    User? GetUserByUsername(string username);
    void Add(User user);
}
