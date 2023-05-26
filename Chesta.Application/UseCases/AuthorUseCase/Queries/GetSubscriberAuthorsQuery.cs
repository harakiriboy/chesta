using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;
using MediatR;

namespace Chesta.Application.UseCases.AuthorUseCase.Queries
{
    public class GetSubscriberAuthorsQuery : IRequest<IEnumerable<Author>>
    {
        public int UserId { get; set; }

        public GetSubscriberAuthorsQuery(int id)
        {
            UserId = id;
        }
    }
}