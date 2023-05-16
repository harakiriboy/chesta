using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.AuthorUseCase.Queries
{
    public class GetAuthorsByUsernameQueryHandler : IRequestHandler<GetAuthorsByUsernameQuery, IEnumerable<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorsByUsernameQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> Handle(GetAuthorsByUsernameQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetByUsernameAndTag(request.Username, request.Tag);
            return authors;
        }
    }
}