using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.UseCases.PublicationUseCase.Commands.CreatePublication;
using Chesta.Contracts.Publications;
using Mapster;

namespace Chesta.Api.Common.Mapping
{
    public class PublicationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreatePublicationRequest, CreatePublicationCommand>();
        }
    }
}