using InvoiceSystem.DOMAIN.Entities;
using InvoiceSystem.DOMAIN.Interfaces.CommonCRUD;

namespace InvoiceSystem.DOMAIN.Interfaces
{
    public interface IProductCategoryRepository : INPRepository<ProductCategory, int>
    {
    }
}
