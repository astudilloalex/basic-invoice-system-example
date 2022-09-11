namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int Id { get; set; }
        public long CustomerId { get; set; }
        public short PaymentMethodId { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
