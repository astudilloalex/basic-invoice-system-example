namespace InvoiceSystem.DOMAIN.Interfaces.CommonCRUD
{
    public interface INPRepository<T, ID> : IPagingAndSortingRepository<T, ID> where T : class
    {
    }
}
