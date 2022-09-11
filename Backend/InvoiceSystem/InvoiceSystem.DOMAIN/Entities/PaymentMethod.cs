namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Invoices = new HashSet<Invoice>();
        }

        public short Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
