using CostCraft.Domain.User;
using CostCraft.Domain.User.ValueObjects;

namespace CostCraft.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserById(UserId id);
    User? GetUserByUsername(string username);
    void Add(User user);
}
