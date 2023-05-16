using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Authentication.Common;
using Chesta.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Chesta.Application.Authentication.Queries.CurrentAuthor
{
    public class GetCurrentAuthorQuery : IRequest<Author>
    {
        public int UserId { get; set; }

        public GetCurrentAuthorQuery(int id)
        {
            UserId = id;
        }   
    }
}