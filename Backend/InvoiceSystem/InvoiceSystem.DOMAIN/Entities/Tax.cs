namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Tax
    {
        public Tax()
        {
            OutputProductTaxes = new HashSet<OutputProductTax>();
            Products = new HashSet<Product>();
        }

        public short Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public double Percentage { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<OutputProductTax> OutputProductTaxes { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
