using InvoiceSystem.DOMAIN.Entities;
using InvoiceSystem.DOMAIN.Interfaces.CommonCRUD;

namespace InvoiceSystem.DOMAIN.Interfaces
{
    public interface ISupplierRepository : INPRepository<Supplier, long>
    {
    }
}
