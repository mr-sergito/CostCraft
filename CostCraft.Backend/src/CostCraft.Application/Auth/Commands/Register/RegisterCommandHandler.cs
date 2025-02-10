using CostCraft.Application.Auth.Common;
using CostCraft.Application.Common.Interfaces.Auth;
using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Domain.Common.Errors;
using CostCraft.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Auth.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthResult>>
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

    public async Task<ErrorOr<AuthResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Validate the user doesn't exist
        if (_userRepository.GetUserByUserName(command.userName) is not null)
        {
            return Errors.User.DuplicateUserName;
        }

        // Create user (generate unique ID) & Persist to DB
        var user = User.Create(
            command.userName,
            command.Password,
            command.PreferredCurrency);

        _userRepository.Add(user);

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(user, token);
    }
}
