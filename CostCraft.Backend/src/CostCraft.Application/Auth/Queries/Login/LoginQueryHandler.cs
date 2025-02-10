using CostCraft.Application.Auth.Common;
using CostCraft.Application.Common.Interfaces.Auth;
using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Domain.Common.Errors;
using CostCraft.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Auth.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Validate the user exists
        if (_userRepository.GetUserByUserName(query.UserName) is not User user)
        {
            return new[] { Errors.Auth.InvalidCredentials };
        }

        // Validate the password is correct
        if (user.Password != query.Password)
        {
            return new[] { Errors.Auth.InvalidCredentials };
        }

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);
    }
}
