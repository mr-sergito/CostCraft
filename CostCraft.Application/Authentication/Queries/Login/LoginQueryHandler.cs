using CostCraft.Application.Authentication.Common;
using CostCraft.Application.Common.Interfaces.Authentication;
using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Domain.Common.Errors;
using CostCraft.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
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

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Validate the user exists
        if (_userRepository.GetUserByuserName(query.UserName) is not User user)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
        }

        // Validate the password is correct
        if (user.Password != query.Password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };
        }

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
