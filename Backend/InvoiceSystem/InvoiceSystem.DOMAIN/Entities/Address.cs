namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Address
    {
        public Address()
        {
            Establishments = new HashSet<Establishment>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public long? PersonId { get; set; }
        public long? CoordinateId { get; set; }
        public string MainStreet { get; set; } = null!;
        public string? SecondaryStreet { get; set; }
        public string? Number { get; set; }
        public string? PostalCode { get; set; }
        public bool Main { get; set; }
        public bool Active { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Coordinate? Coordinate { get; set; }
        public virtual Person? Person { get; set; }
        public virtual ICollection<Establishment> Establishments { get; set; }
    }
}
