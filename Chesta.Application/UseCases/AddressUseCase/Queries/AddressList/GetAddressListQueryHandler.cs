using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Application.UseCases.AddressUseCase.Dto;
using MapsterMapper;
using MediatR;

namespace Chesta.Application.UseCases.AddressUseCase.Queries
{
    public class GetAddressListQueryHandler : IRequestHandler<GetAddressListQuery, IEnumerable<AddressDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetAddressListQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressDto>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var addresses = await _addressRepository.GetAll<AddressDto>(cancellationToken);
            return addresses;
        }
    }
}