namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Establishment
    {
        public Establishment()
        {
            Phones = new HashSet<Phone>();
        }

        public int Id { get; set; }
        public int AddressId { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool Parent { get; set; }
        public bool Active { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual Company Company { get; set; } = null!;
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
