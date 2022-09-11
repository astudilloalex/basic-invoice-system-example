namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class DialInCode
    {
        public DialInCode()
        {
            Phones = new HashSet<Phone>();
        }

        public short Id { get; set; }
        public short CountryId { get; set; }
        public string Code { get; set; } = null!;
        public bool Active { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
