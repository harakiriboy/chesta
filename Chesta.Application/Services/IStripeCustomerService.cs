using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;

namespace Chesta.Application.Services
{
    public interface IStripeCustomerService
    {
        Task<string> CreateStripeCustomer(User user);
    }
}