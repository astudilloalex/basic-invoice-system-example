namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public long PersonId { get; set; }

        public virtual Person Person { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
