using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chesta.Infrastructure.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ChestaDbContext _context;

        public AuthorRepository(ChestaDbContext context)
        {
            _context = context;
        }

        public async Task<Author> Add(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            var newauthor = await _context.Authors.FirstOrDefaultAsync(x => x.Id == author.Id);
            return newauthor;
        }
    }
}