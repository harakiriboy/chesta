using Chesta.Domain.Entities;

namespace Chesta.Application.Common.Interfaces.Persistence
{
    public interface IAddressRepository : IGenericRepository<Address> 
    {
        Task<Address> GetAddressById(int id);
        void Insert(Address address);
        Task<IEnumerable<AddressDto>> GetAll<AddressDto>(CancellationToken cancellationToken);
    }
}