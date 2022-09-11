namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public short CountryId { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; } = null!;
        public bool Active { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
