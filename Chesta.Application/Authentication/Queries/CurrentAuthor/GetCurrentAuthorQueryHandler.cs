using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.Authentication.Queries.CurrentAuthor
{
    public class GetCurrentAuthorQueryHandler : IRequestHandler<GetCurrentAuthorQuery, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetCurrentAuthorQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> Handle(GetCurrentAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByUserId(request.UserId);
            return author;
        }
    }
}