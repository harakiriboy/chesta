using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Authentication.Common;
using Chesta.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Chesta.Application.Authentication.Queries.CurrentUser
{
    public class GetCurrentUserQuery : IRequest<ErrorOr<AuthenticationResult>>
    {
        public int UserId { get; set; }
        public string Token { get; set; }

        public GetCurrentUserQuery(int id, string token)
        {
            UserId = id;
            Token = token;
        }
    }
}