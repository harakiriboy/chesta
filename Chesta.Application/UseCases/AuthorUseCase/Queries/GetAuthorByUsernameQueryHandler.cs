using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using MediatR;

namespace Chesta.Application.UseCases.AuthorUseCase.Queries
{
    public class GetAuthorByUsernameQueryHandler : IRequestHandler<GetAuthorByUsernameQuery, bool>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorByUsernameQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<bool> Handle(GetAuthorByUsernameQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByUsername(request.Username);
            if(author is null) {
                return false;
            }
            return true;
        }
    }
}