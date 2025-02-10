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
        return _dbCcontext.Users.SingleOrDefault(u => u.Id == id);
    }

    public User? GetUserByuserName(string userName)
    {
        return _dbCcontext.Users.SingleOrDefault(u => u.UserName == userName);
    }

    public void Update(User user)
    {
        _dbCcontext.Update(user);
        _dbCcontext.SaveChanges();
    }

    public void Remove(UserId id)
    {
        _dbCcontext.Remove(id);
    }
}
