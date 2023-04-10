using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chesta.Infrastructure.Persistence.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public ChestaDbContext context { get; set; }
        public AddressRepository(ChestaDbContext context)
        {
            this.context = context;
        }        

        public async Task<Address?> GetAddressById(int id)
        {
            return await context.Address.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async void Insert(Address address)
        {
            await context.AddAsync(address);
            await context.SaveChangesAsync();
        }

        public async Task<IQueryable<Address>> GetAll()
        {
            var addresses = await context.Address.AsQueryable().ToListAsync();
            return (IQueryable<Address>)addresses;
        }
    }
}