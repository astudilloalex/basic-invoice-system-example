namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class InvoiceDetail
    {
        public InvoiceDetail()
        {
            OutputProductTaxes = new HashSet<OutputProductTax>();
        }

        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public decimal Cost { get; set; }
        public double ProfitPercentage { get; set; }
        public bool Active { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<OutputProductTax> OutputProductTaxes { get; set; }
    }
}
