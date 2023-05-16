using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.AuthorUseCase.Queries
{
    public class GetAuthorsByUsernameQuery : IRequest<IEnumerable<Author>>
    {
        public string Username { get; set; } = null!;
        public string Tag { get; set; } = null!;
    }
}