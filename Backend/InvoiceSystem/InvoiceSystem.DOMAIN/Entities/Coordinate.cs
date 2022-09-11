namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Coordinate
    {
        public Coordinate()
        {
            Addresses = new HashSet<Address>();
        }

        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
