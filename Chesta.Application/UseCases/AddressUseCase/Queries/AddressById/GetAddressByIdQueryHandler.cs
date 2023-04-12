using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Application.UseCases.AddressUseCase.Dto;
using Chesta.Domain.Specifications;
using MediatR;

namespace Chesta.Application.UseCases.AddressUseCase.Queries.AddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressDto>
    {
        private readonly IAddressRepository _addressRepository;

        public GetAddressByIdQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetByIdAsync<AddressDto>(AddressSpecs.ById(request.Id));
            return address;
        }
    }
}