using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Domain.User;
using CostCraft.Domain.User.ValueObjects;

namespace CostCraft.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserById(UserId id)
    {
        return _users.SingleOrDefault(u => u.Id == id);
    }

    public User? GetUserByUsername(string username)
    {
        return _users.SingleOrDefault(u => u.Username == username);
    }
}
