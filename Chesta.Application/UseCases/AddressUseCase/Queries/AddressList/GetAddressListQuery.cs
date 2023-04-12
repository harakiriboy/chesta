using Chesta.Application.UseCases.AddressUseCase.Dto;
using MediatR;

namespace Chesta.Application.UseCases.AddressUseCase.Queries
{
    public class GetAddressListQuery : IRequest<IEnumerable<AddressDto>>
    {
        public GetAddressListQuery() {
            
        }
    }
}