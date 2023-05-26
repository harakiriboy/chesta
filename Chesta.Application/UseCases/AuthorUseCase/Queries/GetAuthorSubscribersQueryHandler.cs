using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.AuthorUseCase.Queries
{
    public class GetAuthorSubscribersQueryHandler : IRequestHandler<GetAuthorSubscribersQuery, IEnumerable<User>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;

        public GetAuthorSubscribersQueryHandler(ISubscriptionRepository subscriptionRepository, 
        IAuthorRepository authorRepository, IUserRepository userRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _authorRepository = authorRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetAuthorSubscribersQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByUsername(request.Username);
            var userIds = await _subscriptionRepository.GetByAuthorId(author!.Id);
            var users = await _userRepository.GetByIds(userIds);
            return users;
        }
    }
}