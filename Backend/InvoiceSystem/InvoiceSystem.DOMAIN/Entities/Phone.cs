namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Phone
    {
        public int Id { get; set; }
        public short DialInCodeId { get; set; }
        public long? PersonId { get; set; }
        public int? EstablishmentId { get; set; }
        public string Number { get; set; } = null!;
        public bool Main { get; set; }
        public bool Active { get; set; }

        public virtual DialInCode DialInCode { get; set; } = null!;
        public virtual Establishment? Establishment { get; set; }
        public virtual Person? Person { get; set; }
    }
}
