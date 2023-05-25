using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public async Task<bool> DeleteById(int id)
        {
            var publication = await _context.Publications.Where(x => x.Id == id).AsQueryable().FirstOrDefaultAsync();
            if(publication is not null) {
                _context.Publications.Remove(publication);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Publication>> GetByAuthorId(int id) {
            var publications = await _context.Publications.Where(x => x.AuthorId == id).AsQueryable().ToListAsync();
            return publications;
        }

        public async Task<Publication> GetByAuthorIdAndVideoLink(int id, string link)
        {
            var publication = await _context.Publications.Where(x => x.AuthorId == id && x.VideoLink == link).AsQueryable().FirstOrDefaultAsync();
            return publication!;
        }

        public async Task<Publication> UpdatePublication(Publication pub)
        {
            _context.Publications.Update(pub);
            await _context.SaveChangesAsync();
            return pub;
        }
    }
}