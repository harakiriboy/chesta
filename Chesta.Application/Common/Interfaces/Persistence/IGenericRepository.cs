using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSpecifications;

namespace Chesta.Application.Common.Interfaces.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TItem> GetByIdAsync<TItem>(ASpec<TEntity> spec);
        Task<TEntity> GetByIdAsync(ASpec<TEntity> spec);
        Task<IEnumerable<TItem>> GetAllByIdAsync<TItem>(ASpec<TEntity> spec);
        Task<IEnumerable<TItem>> GetAllAsync<TItem>(CancellationToken cancellationToken);
        Task AddAsync(TEntity entity);

    }
}