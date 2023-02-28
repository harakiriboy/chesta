using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Authentication.Commands.Register;
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
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();
            
            config.NewConfig<AuthenticationResult, AuthenticationReponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}