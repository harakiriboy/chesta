using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Authentication.Commands.RegisterAuthor;
using Chesta.Domain.Entities;

namespace Chesta.Application.Services
{
    public interface IStripeAccountService
    {
        Task<string> CreateConnectedAccount(RegisterAuthorCommand command);
    }
}