using CostCraft.Application.Auth.Commands.Register;
using CostCraft.Application.Auth.Common;
using CostCraft.Application.Auth.Queries.Login;
using CostCraft.Contracts.Auth;
using Mapster;

namespace CostCraft.Api.Common.Mapping;

public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthResult, AuthResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest.UserName, src => src.User.UserName)
            .Map(dest => dest.Token, src => src.Token);
    }
}
