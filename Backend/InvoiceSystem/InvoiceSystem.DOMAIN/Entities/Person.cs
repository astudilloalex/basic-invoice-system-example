namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Person
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
            Companies = new HashSet<Company>();
            Phones = new HashSet<Phone>();
            Users = new HashSet<User>();
        }

        public long Id { get; set; }
        public short DocumentTypeId { get; set; }
        public short? GenderId { get; set; }
        public string IdCard { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? SocialReason { get; set; }
        public bool JuridicalPerson { get; set; }
        public bool Active { get; set; }

        public virtual PersonDocumentType DocumentType { get; set; } = null!;
        public virtual Gender? Gender { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
