using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chesta.Infrastructure.Persistence.Repositories
{
    public class SubscriptionRepository : GenericRepository<Subscription>, ISubscriptionRepository
    {
        private readonly ChestaDbContext _context;
        public SubscriptionRepository(ChestaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<int>> GetByUserAndPlans(int userId, int[] plans)
        {
            List<int> existingPlans = new List<int>();
            foreach(int i in plans) {
                var sub = await _context.Subscriptions.Where(x => x.UserId == userId && x.SubscriptionPlanId == i).AsQueryable().FirstOrDefaultAsync();
                if(sub is not null) {
                    existingPlans.Add(i);
                }
            }
            return existingPlans;
        }
    }
}