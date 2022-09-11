namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class PersonDocumentType
    {
        public PersonDocumentType()
        {
            People = new HashSet<Person>();
        }

        public short Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Active { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
