using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.AuthorUseCase.Queries
{
    public class GetAuthorSubscribersQuery : IRequest<IEnumerable<User>>
    {
        public string Username { get; set; } = null!;

        public GetAuthorSubscribersQuery(string username)
        {
            Username = username;
        }
    }
}