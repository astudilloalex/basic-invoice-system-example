namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class OutputProductTax
    {
        public int Id { get; set; }
        public short TaxId { get; set; }
        public int InvoiceDetailId { get; set; }
        public double Percentage { get; set; }

        public virtual InvoiceDetail InvoiceDetail { get; set; } = null!;
        public virtual Tax Tax { get; set; } = null!;
    }
}
