namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public long PersonId { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
