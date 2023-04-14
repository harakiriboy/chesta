using Chesta.Application.UseCases.PublicationUseCase.Commands.CreatePublication;
using Chesta.Contracts.Publications;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chesta.Api.Controllers
{
    [Route("publications")]
    [Authorize]
    public class PublicationsController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public PublicationsController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePublicationRequest request) {
            var command = _mapper.Map<CreatePublicationCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}