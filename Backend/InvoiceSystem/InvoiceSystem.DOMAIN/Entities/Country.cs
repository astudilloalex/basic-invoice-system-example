namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            DialInCodes = new HashSet<DialInCode>();
        }

        public short Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<DialInCode> DialInCodes { get; set; }
    }
}
