using System.Security.Claims;
using Chesta.Application.UseCases.AuthorUseCase.Queries;
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

        [HttpGet("getByUsername")]
        public async Task<IEnumerable<Author>> GetAuthorsByUsername(string username, string? tags = null) 
        {
            var request = new GetAuthorsByUsernameRequest(username, tags);
            var query = _mapper.Map<GetAuthorsByUsernameQuery>(request);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("getAuthorByUsername")]
        public async Task<bool> GetAuthorByUsername(string username) {
            var query = new GetAuthorByUsernameQuery(username);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("getAuthorSubscribers")]
        public async Task<IEnumerable<User>> GetAuthorSubscribers(string username) {
            var query = new GetAuthorSubscribersQuery(username);
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpGet("getSubscriberAuthors")]
        public async Task<IEnumerable<Author>> GetSubscriberAuthors(int userId) {
            userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var query = new GetSubscriberAuthorsQuery(userId);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}