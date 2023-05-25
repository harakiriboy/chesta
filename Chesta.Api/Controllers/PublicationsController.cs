using Chesta.Application.UseCases.PublicationUseCase.Commands.CreatePublication;
using Chesta.Application.UseCases.PublicationUseCase.Commands.DeletePublication;
using Chesta.Application.UseCases.PublicationUseCase.Commands.UpdatePublication;
using Chesta.Application.UseCases.PublicationUseCase.Queries.GetAllPublicationsByAuthor;
using Chesta.Contracts.Publications;
using Chesta.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chesta.Api.Controllers
{
    [Route("chesta/publications")]
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

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(CreatePublicationRequest request) {
            var command = _mapper.Map<UpdatePublicationCommand>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id) {
            var command = new DeletePublicationCommand(id);
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Publication>> GetByAuthor(string authorUsername) {
            var query =new GetAllPublicationsByAuthorQuery(authorUsername);
            var result = await _mediator.Send(query);
            if(result is null) {
                var list = new List<Publication>();
                var pub = new Publication();
                list.Add(pub);
                return list;
            }
            return result;
        }
    }
}