using CostCraft.Application.Authentication.Commands.Register;
using CostCraft.Application.Authentication.Common;
using CostCraft.Application.Authentication.Queries.Login;
using CostCraft.Contracts.Authentication;
using Mapster;

namespace CostCraft.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest.Username, src => src.User.Username)
            .Map(dest => dest.Token, src => src.Token);
    }
}
