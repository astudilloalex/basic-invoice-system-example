using InvoiceSystem.DOMAIN.Entities;
using InvoiceSystem.DOMAIN.Interfaces;

namespace InvoiceSystem.INFRASTRUCTURE.Repositories
{
    public class AddressRepository : NPRepository<Address, int>, IAddressRepository
    {
        public AddressRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
