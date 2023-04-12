using Chesta.Application.UseCases.AddressUseCase.Dto;
using Chesta.Application.UseCases.AddressUseCase.Queries;
using Chesta.Application.UseCases.AddressUseCase.Queries.AddressById;
using Chesta.Application.UseCases.AddressUseCase.Queries.FullAddressById;
using Chesta.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chesta.Api.Controllers
{
    [Route("chesta/address")]
    [AllowAnonymous]
    public class AddressController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AddressController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            return await _mediator.Send(new GetAddressListQuery());
        }

        [HttpGet("{id}/fullbody")]
        public async Task<Address> GetFullAddressById(int id) {
            return await _mediator.Send(new GetFullAddressByIdQuery(id));
        }

        [HttpGet("{id}")]
        public async Task<AddressDto> GetAddressById(int id) {
            return await _mediator.Send(new GetAddressByIdQuery(id));
        }
    }
}