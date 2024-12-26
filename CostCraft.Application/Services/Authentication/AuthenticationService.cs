using CostCraft.Application.Common.Interfaces.Authentication;
using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Domain.Entities;

namespace CostCraft.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string username, string password)
    {
        // Validate the user exists
        if (_userRepository.GetUserByUsername(username) is not User user)
        {
            throw new Exception("User with given username does not exist.");
        }

        // Validate the password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(string username, string password)
    {
        // Validate the user doesn't exist
        if (_userRepository.GetUserByUsername(username) is not null)
        {
            throw new Exception("User with given username already exists.");
        }

        // Create user (generate unique ID) & Persist to DB
        var user = new User
        {
            Username = username,
            Password = password,
        };

        _userRepository.Add(user);

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
