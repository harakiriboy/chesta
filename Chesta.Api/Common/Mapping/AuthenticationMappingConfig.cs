using Chesta.Application.Authentication.Commands.RegisterAuthor;
using Chesta.Application.Authentication.Commands.RegisterSubscriber;
using Chesta.Application.Authentication.Common;
using Chesta.Application.Authentication.Queries.Login;
using Chesta.Contracts.Authentication;
using Mapster;

namespace Chesta.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterUserRequest, RegisterSubscriberCommand>();

            config.NewConfig<RegisterAuthorRequest, RegisterAuthorCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();
            
            config.NewConfig<AuthenticationResult, AuthenticationReponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}