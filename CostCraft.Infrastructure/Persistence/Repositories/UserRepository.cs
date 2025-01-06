using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Domain.UserAggregate;
using CostCraft.Domain.UserAggregate.ValueObjects;

namespace CostCraft.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CostCraftDbCcontext _dbCcontext;

    public UserRepository(CostCraftDbCcontext dbCcontext)
    {
        _dbCcontext = dbCcontext;
    }

    public void Add(User user)
    {
        _dbCcontext.Add(user);
        _dbCcontext.SaveChanges();
    }

    public User? GetUserById(UserId id)
    {
        return default(User?);

        //return _dbCcontext.SingleOrDefault(u => u.Id == id);
    }

    public User? GetUserByUsername(string username)
    {
        return default(User?);

        //return _dbCcontext.SingleOrDefault(u => u.Username == username);
    }
}
