using InvoiceSystem.DOMAIN.Entities;
using InvoiceSystem.DOMAIN.Interfaces;

namespace InvoiceSystem.INFRASTRUCTURE.Repositories
{
    public class CountryRepository : NPRepository<Country, short>, ICountryRepository
    {
        public CountryRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
