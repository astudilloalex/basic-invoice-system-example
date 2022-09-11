namespace InvoiceSystem.DOMAIN.Entities
{
    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public long Id { get; set; }
        public long PersonId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool AccountNonExpired { get; set; }
        public bool AccountNonLocked { get; set; }
        public bool CredentialsNonExpired { get; set; }
        public bool Enabled { get; set; }

        public virtual Person Person { get; set; } = null!;

        public virtual ICollection<Role> Roles { get; set; }
    }
}
