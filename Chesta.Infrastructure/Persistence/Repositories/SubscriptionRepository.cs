using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;

namespace Chesta.Infrastructure.Persistence.Repositories
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        private readonly ChestaDbContext _context;
        public SubscriptionRepository(ChestaDbContext context) : base(context)
        {
            _context = context;
        }
    }
}