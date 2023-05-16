using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Chesta.Application.UseCases.AuthorUseCase.Queries
{
    public class GetAuthorByUsernameQuery : IRequest<bool>
    {
        public string Username { get; set; } = null!;

        public GetAuthorByUsernameQuery(string username)
        {
            Username = username;            
        }
    }
}