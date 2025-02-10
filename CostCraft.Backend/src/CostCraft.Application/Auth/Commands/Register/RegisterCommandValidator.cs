using FluentValidation;

namespace CostCraft.Application.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.userName).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.PreferredCurrency).NotEmpty();
    }
}
