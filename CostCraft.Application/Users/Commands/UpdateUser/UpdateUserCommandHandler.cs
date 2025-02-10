using CostCraft.Application.Common.Interfaces.Persistence;
using CostCraft.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace CostCraft.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand, ErrorOr<User>>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var user = User.Create(
            userName: request.UserName,
            password: request.Password,
            preferredCurrency: request.PreferredCurrency);

        _userRepository.Update(user);

        return user!;
    }
}
