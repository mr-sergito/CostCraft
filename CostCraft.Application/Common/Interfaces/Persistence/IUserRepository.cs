using CostCraft.Domain.UserAggregate;
using CostCraft.Domain.UserAggregate.ValueObjects;

namespace CostCraft.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void Add(User user);
    User? GetUserById(UserId id);
    User? GetUserByuserName(string userName);
    void Update(User user);
    void Remove(UserId id);
}
