namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class Company
    {
        public Company()
        {
            Establishments = new HashSet<Establishment>();
        }

        public int Id { get; set; }
        public long PersonId { get; set; }
        public string Tradename { get; set; } = null!;
        public bool KeepAccounts { get; set; }
        public bool SpecialTaxpayer { get; set; }
        public int? SpecialTaxpayerNumber { get; set; }
        public bool Active { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<Establishment> Establishments { get; set; }
    }
}
