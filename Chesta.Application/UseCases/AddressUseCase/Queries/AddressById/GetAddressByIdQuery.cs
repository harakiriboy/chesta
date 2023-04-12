using Chesta.Application.UseCases.AddressUseCase.Dto;
using MediatR;

namespace Chesta.Application.UseCases.AddressUseCase.Queries.AddressById
{
    public class GetAddressByIdQuery : IRequest<AddressDto>
    {
        public int Id { get; set; }

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}