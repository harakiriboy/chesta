using Chesta.Application.Common.Interfaces.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;
using NSpecifications;

namespace Chesta.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ChestaDbContext _context;

        public GenericRepository(ChestaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TItem>> GetAllAsync<TItem>(CancellationToken cancellationToken) {
            var res = await _context.Set<TEntity>().ProjectToType<TItem>().AsQueryable().ToListAsync();
            return res;
        }

        public async Task<TItem> GetByIdAsync<TItem>(ASpec<TEntity> spec)
        {
            var res = await _context.Set<TEntity>().Where(spec).ProjectToType<TItem>().AsQueryable().FirstOrDefaultAsync();
            return res;
        }

        public async Task<TEntity> GetByIdAsync(ASpec<TEntity> spec)
        {
            var res = await _context.Set<TEntity>().Where(spec).AsQueryable().FirstOrDefaultAsync();
            return res;
        }

        public async Task AddAsync(TEntity entity) 
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}