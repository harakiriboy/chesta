using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Domain.Entities;

namespace Chesta.Application.Common.Interfaces.Persistence
{
    public interface IAuthorRepository : IGenericRepository<Author> {
        Task<Author> Add(Author author);
        Task<Author> GetByUserId(int id);
        Task<Author?> GetByUsername(string username);
        Task<IEnumerable<Author>> GetByUsernameAndTag(string username, string tag);
        Task<IEnumerable<Author>> GetByIds(List<int> ids);
    }
}