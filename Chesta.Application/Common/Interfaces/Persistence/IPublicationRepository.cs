using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;

namespace Chesta.Application.Common.Interfaces.Persistence
{
    public interface IPublicationRepository : IGenericRepository<Publication>
    {
        Task<IEnumerable<Publication>> GetByAuthorId(int id);
    }
}