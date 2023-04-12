using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.AddressUseCase.Queries.FullAddressById
{
    public class GetFullAddressByIdQueryHandler : IRequestHandler<GetFullAddressByIdQuery, Address>
    {
        private readonly IAddressRepository _addressRepository;

        public GetFullAddressByIdQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Task<Address> Handle(GetFullAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var address = _addressRepository.GetAddressById(request.Id);
            return address;
        }
    }
}