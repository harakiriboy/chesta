using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;

namespace Chesta.Application.Common.Interfaces.Persistence
{
    public interface ISubscriptionRepository : IGenericRepository<Subscription>
    {
        Task<List<int>> GetByUserAndPlans(int id, int[] plans);
        Task<List<int>> GetByAuthorId(int id);
        Task<List<int>> GetByUserId(int id);
    }
}