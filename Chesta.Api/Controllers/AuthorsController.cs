using Chesta.Application.UseCases.AuthorUseCase.Commands;
using Chesta.Contracts.AuthorContracts;
using Chesta.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chesta.Api.Controllers
{
    [Route("chesta/author")]
    [AllowAnonymous]
    public class AuthorsController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthorsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddAuthorRequest request)
        {
            var command = _mapper.Map<AddAuthorCommand>(request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}