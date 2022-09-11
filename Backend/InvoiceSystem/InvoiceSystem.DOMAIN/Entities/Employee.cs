namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Employee
    {
        public long PersonId { get; set; }

        public virtual Person Person { get; set; } = null!;
    }
}
