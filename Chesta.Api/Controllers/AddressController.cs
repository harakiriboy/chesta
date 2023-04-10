using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chesta.Api.Controllers
{
    [Route("address")]
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

        // [HttpGet]
        // public async Task<Address> GetAll()
        // {
            
        // }
    }
}