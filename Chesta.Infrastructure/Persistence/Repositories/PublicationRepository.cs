using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chesta.Infrastructure.Persistence.Repositories
{
    public class PublicationRepository : GenericRepository<Publication>, IPublicationRepository
    {
        private readonly ChestaDbContext _context;
        public PublicationRepository(ChestaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publication>> GetByAuthorId(int id) {
            var publications = await _context.Publications.Where(x => x.AuthorId == id).AsQueryable().ToListAsync();
            return publications;
        }
    }
}