using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;

namespace Chesta.Infrastructure.Persistence.Repositories
{
    public class SubscriptionPlanRepository : GenericRepository<SubscriptionPlan>, ISubscriptionPlanRepository
    {
        private readonly ChestaDbContext _context;
        public SubscriptionPlanRepository(ChestaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SubscriptionPlan> UpdatePlan(SubscriptionPlan plan)
        {
            _context.SubscriptionPlans.Update(plan);
            await _context.SaveChangesAsync();
            return plan;
        }
    }
}