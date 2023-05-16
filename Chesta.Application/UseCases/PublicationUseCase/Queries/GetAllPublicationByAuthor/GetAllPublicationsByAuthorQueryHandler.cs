using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.PublicationUseCase.Queries.GetAllPublicationsByAuthor
{
    public class GetAllPublicationsByAuthorQueryHandler : IRequestHandler<GetAllPublicationsByAuthorQuery, IEnumerable<Publication>?>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublicationRepository _publicationRepository;

        public GetAllPublicationsByAuthorQueryHandler(IAuthorRepository authorRepository, IPublicationRepository publicationRepository)
        {
            _authorRepository = authorRepository;
            _publicationRepository = publicationRepository;
        }
        public async Task<IEnumerable<Publication>?> Handle(GetAllPublicationsByAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByUsername(request.AuthorUsername);
            if(author is null) {
                return null;
            }
            var publications = await _publicationRepository.GetByAuthorId(author.Id);
            return publications;
        }
    }
}