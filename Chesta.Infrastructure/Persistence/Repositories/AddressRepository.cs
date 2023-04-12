using Chesta.Application.Common.Interfaces.Persistence;
using Chesta.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Chesta.Infrastructure.Persistence.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        ChestaDbContext context;
        public AddressRepository(ChestaDbContext context) : base(context)
        {
            this.context = context;
        }        

        public async Task<Address> GetAddressById(int id)
        {
            var address = await context.Address.FirstOrDefaultAsync(x => x.Id == id);
            if (address is null) {
                return null;
            }
            return address;
        }

        public async void Insert(Address address)
        {
            await context.AddAsync(address);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AddressDto>> GetAll<AddressDto>(CancellationToken cancellationToken)
        {
            var addresses = await context.Address.ProjectToType<AddressDto>().AsQueryable().ToListAsync();
            return addresses;
        }
    }
}