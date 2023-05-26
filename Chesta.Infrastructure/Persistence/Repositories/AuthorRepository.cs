using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chesta.Infrastructure.Persistence.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly ChestaDbContext _context;

        public AuthorRepository(ChestaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Author> Add(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            var newauthor = await _context.Authors.FirstOrDefaultAsync(x => x.Id == author.Id);
            return newauthor!;
        }

        public async Task<Author> GetByUserId(int id)
        {
            var author = await _context.Authors.Where(x => x.UserId == id).FirstOrDefaultAsync();
            return author!;
        }

        public async Task<Author?> GetByUsername(string username)
        {
            var usernameLower = username.Trim().ToLower();
            var author = await _context.Authors.Where(x => x.AuthorUsername.ToLower() == usernameLower).AsQueryable().FirstOrDefaultAsync();
            if(author is null) {
                return null;
            }
            return author;
        }

        public async Task<IEnumerable<Author>> GetByUsernameAndTag(string username, string tags)
        {
            var usernameLower = username.Trim().ToLower();
            if (tags is not null) {
                var taglist = new List<string>();
                taglist.AddRange(tags.ToLower().Split(",").ToList());
                return await _context.Authors.Where(x => x.AuthorUsername.ToLower().Contains(usernameLower) && (taglist.Count == 0 || taglist.Contains(x.Tag.ToLower()))).AsQueryable().ToListAsync();
            }
            var authors = await _context.Authors.Where(x => x.AuthorUsername.ToLower().Contains(usernameLower)).AsQueryable().ToListAsync();
            return authors;
        }

        public async Task<IEnumerable<Author>> GetByIds(List<int> ids) {
            var authors = await _context.Authors.Where(author => ids.Contains(author.Id)).Distinct().ToListAsync();
            return authors;
        }
    }
}