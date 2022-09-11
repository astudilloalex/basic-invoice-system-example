using InvoiceSystem.DOMAIN.Entities;
using InvoiceSystem.DOMAIN.Interfaces.CommonCRUD;

namespace InvoiceSystem.DOMAIN.Interfaces
{
    public interface IInvoiceDetailRepository : INPRepository<InvoiceDetail, int>
    {
    }
}
