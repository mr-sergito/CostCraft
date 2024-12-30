using CostCraft.Application.Common.Interfaces.Authentication;
using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Application.Services.Authentication.Common;
using CostCraft.Domain.Common.Errors;
using CostCraft.Domain.Entities;
using ErrorOr;

namespace CostCraft.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string username, string password)
    {
        // Validate the user doesn't exist
        if (_userRepository.GetUserByUsername(username) is not null)
        {
            return Errors.User.DuplicateUsername;
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
