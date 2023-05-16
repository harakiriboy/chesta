using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Chesta.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Chesta.Infrastructure.Persistence
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ChestaDbContext _context;

        public UserRepository(ChestaDbContext context) : base(context)
        {
            _context = context;
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User Add(User user)
        {
            _context.Users.AddAsync(user);
            _context.SaveChanges();
            var newuser = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            return newuser!;
        }
    }
}