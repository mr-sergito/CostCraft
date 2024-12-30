using CostCraft.Application.Common.Interfaces.Authentication;
using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Application.Authentication.Common;
using CostCraft.Domain.Common.Errors;
using CostCraft.Domain.Entities;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator, 
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // Validate the user doesn't exist
        if (_userRepository.GetUserByUsername(command.Username) is not null)
        {
            return Errors.User.DuplicateUsername;
        }

        // Create user (generate unique ID) & Persist to DB
        var user = new User
        {
            Username = command.Username,
            Password = command.Password,
        };

        _userRepository.Add(user);

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
