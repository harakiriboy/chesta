using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.AuthorUseCase.Queries
{
    public class GetSubscriberAuthorsQueryHandler : IRequestHandler<GetSubscriberAuthorsQuery, IEnumerable<Author>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;

        public GetSubscriberAuthorsQueryHandler(IAuthorRepository authorRepository, ISubscriptionRepository subscriptionRepository, IUserRepository userRepository)
        {
            _authorRepository = authorRepository;
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<Author>> Handle(GetSubscriberAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authorIds = await _subscriptionRepository.GetByUserId(request.UserId);
            var authors = await _authorRepository.GetByIds(authorIds);
            return authors;
        }
    }
}