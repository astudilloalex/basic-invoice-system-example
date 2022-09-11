using InvoiceSystem.DOMAIN.Entities;
using InvoiceSystem.DOMAIN.Interfaces.CommonCRUD;
using InvoiceSystem.DOMAIN.Utilities.CommonCRUD;
using InvoiceSystem.INFRASTRUCTURE.Repositories;

namespace InvoiceSystem.APPLICATION.Services
{
    public class CountryService
    {
        private readonly CountryRepository _repository;

        public CountryService(CountryRepository repository)
        {
            _repository = repository;
        }

        public IPage<Country> FindAll(int page, int size)
        {
            return _repository.FindAll(PageRequest.Of(page, size));
        }
    }
}
