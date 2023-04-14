using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;

namespace Chesta.Infrastructure.Persistence.Repositories
{
    public class AuthorPlanRepository : GenericRepository<AuthorPlan>, IAuthorPlanRepository
    {
        public AuthorPlanRepository(ChestaDbContext context) : base(context)
        {
        }
    }
}