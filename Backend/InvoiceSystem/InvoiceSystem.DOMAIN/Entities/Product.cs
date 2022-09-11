namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Product
    {
        public Product()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
            Suppliers = new HashSet<Supplier>();
            Taxes = new HashSet<Tax>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public short TypeId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Presentation { get; set; }
        public string? Content { get; set; }
        public decimal Cost { get; set; }
        public double Stock { get; set; }
        public double? StockReplace { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? WarnExpiration { get; set; }
        public double ProfitPercentage { get; set; }
        public bool Active { get; set; }

        public virtual ProductCategory Category { get; set; } = null!;
        public virtual ProductType Type { get; set; } = null!;

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<Tax> Taxes { get; set; }
    }
}
