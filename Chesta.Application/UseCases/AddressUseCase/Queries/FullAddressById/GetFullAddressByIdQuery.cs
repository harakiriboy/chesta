using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.AddressUseCase.Queries.FullAddressById
{
    public class GetFullAddressByIdQuery : IRequest<Address>
    {
        public int Id { get; set; }

        public GetFullAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}