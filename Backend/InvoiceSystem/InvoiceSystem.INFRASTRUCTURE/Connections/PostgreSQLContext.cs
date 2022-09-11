using InvoiceSystem.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceSystem.INFRASTRUCTURE.Connections
{
    public partial class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
        {

        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Coordinate> Coordinates { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DialInCode> DialInCodes { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Establishment> Establishments { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
        public virtual DbSet<OutputProductTax> OutputProductTaxes { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<PersonDocumentType> PersonDocumentTypes { get; set; } = null!;
        public virtual DbSet<Phone> Phones { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Tax> Taxes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("addresses");

                entity.HasIndex(e => e.CityId, "addresses_city_id_idx");

                entity.HasIndex(e => e.CoordinateId, "addresses_coordinate_id_idx");

                entity.HasIndex(e => e.PersonId, "addresses_person_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CoordinateId).HasColumnName("coordinate_id");

                entity.Property(e => e.Main).HasColumnName("main");

                entity.Property(e => e.MainStreet)
                    .HasMaxLength(50)
                    .HasColumnName("main_street");

                entity.Property(e => e.Number)
                    .HasMaxLength(10)
                    .HasColumnName("number");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("postal_code");

                entity.Property(e => e.SecondaryStreet)
                    .HasMaxLength(50)
                    .HasColumnName("secondary_street");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_addresses__city_id");

                entity.HasOne(d => d.Coordinate)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CoordinateId)
                    .HasConstraintName("fk_addresses__coordinate_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("fk_addresses__person_id");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.HasIndex(e => e.CountryId, "cities_country_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .HasColumnName("code");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cities__country_id");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("companies");

                entity.HasIndex(e => e.PersonId, "companies_person_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.KeepAccounts).HasColumnName("keep_accounts");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.SpecialTaxpayer).HasColumnName("special_taxpayer");

                entity.Property(e => e.SpecialTaxpayerNumber).HasColumnName("special_taxpayer_number");

                entity.Property(e => e.Tradename)
                    .HasMaxLength(250)
                    .HasColumnName("tradename");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_companies__person_id");
            });

            modelBuilder.Entity<Coordinate>(entity =>
            {
                entity.ToTable("coordinates");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.HasIndex(e => e.Code, "countries_code_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("customers_pkey");

                entity.ToTable("customers");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customers__person_id");
            });

            modelBuilder.Entity<DialInCode>(entity =>
            {
                entity.ToTable("dial_in_codes");

                entity.HasIndex(e => e.Code, "dial_in_codes_code_key")
                    .IsUnique();

                entity.HasIndex(e => e.CountryId, "dial_in_codes_country_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .HasColumnName("code");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.DialInCodes)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dial_in_codes__country_id");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("employees_pkey");

                entity.ToTable("employees");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employees__person_id");
            });

            modelBuilder.Entity<Establishment>(entity =>
            {
                entity.ToTable("establishments");

                entity.HasIndex(e => e.AddressId, "establishments_address_id_idx");

                entity.HasIndex(e => e.CompanyId, "establishments_company_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");

                entity.Property(e => e.Parent).HasColumnName("parent");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Establishments)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_establishments__address_id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Establishments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_establishments__company_id");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("genders");

                entity.HasIndex(e => e.Name, "genders_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoices");

                entity.HasIndex(e => e.CustomerId, "invoices_customer_id_idx");

                entity.HasIndex(e => e.PaymentMethodId, "invoices_payment_method_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DateTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_time");

                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoices__customer_id");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoices__payment_method_id");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.ToTable("invoice_details");

                entity.HasIndex(e => e.InvoiceId, "invoice_details_invoice_id_idx");

                entity.HasIndex(e => e.ProductId, "invoice_details_product_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Cost)
                    .HasPrecision(19, 5)
                    .HasColumnName("cost");

                entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProfitPercentage).HasColumnName("profit_percentage");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoice_details__invoice_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_invoice_details__product_id");
            });

            modelBuilder.Entity<OutputProductTax>(entity =>
            {
                entity.ToTable("output_product_taxes");

                entity.HasIndex(e => e.InvoiceDetailId, "output_product_taxes_invoice_detail_id_idx");

                entity.HasIndex(e => e.TaxId, "output_product_taxes_tax_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.InvoiceDetailId).HasColumnName("invoice_detail_id");

                entity.Property(e => e.Percentage).HasColumnName("percentage");

                entity.Property(e => e.TaxId).HasColumnName("tax_id");

                entity.HasOne(d => d.InvoiceDetail)
                    .WithMany(p => p.OutputProductTaxes)
                    .HasForeignKey(d => d.InvoiceDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_output_product_taxes__invoice_detail_id");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.OutputProductTaxes)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_output_product_taxes__tax_id");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("payment_methods");

                entity.HasIndex(e => e.Name, "payment_methods_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("persons");

                entity.HasIndex(e => e.DocumentTypeId, "persons_document_type_id_idx");

                entity.HasIndex(e => e.GenderId, "persons_gender_id_idx");

                entity.HasIndex(e => e.IdCard, "persons_id_card_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("birthdate");

                entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.GenderId).HasColumnName("gender_id");

                entity.Property(e => e.IdCard)
                    .HasMaxLength(25)
                    .HasColumnName("id_card");

                entity.Property(e => e.JuridicalPerson).HasColumnName("juridical_person");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.SocialReason)
                    .HasMaxLength(150)
                    .HasColumnName("social_reason");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_persons__document_type_id");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("fk_persons__gender_id");
            });

            modelBuilder.Entity<PersonDocumentType>(entity =>
            {
                entity.ToTable("person_document_types");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phones");

                entity.HasIndex(e => e.DialInCodeId, "phones_dial_in_code_id_idx");

                entity.HasIndex(e => e.EstablishmentId, "phones_establishment_id_idx");

                entity.HasIndex(e => e.Number, "phones_number_key")
                    .IsUnique();

                entity.HasIndex(e => e.PersonId, "phones_person_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.DialInCodeId).HasColumnName("dial_in_code_id");

                entity.Property(e => e.EstablishmentId).HasColumnName("establishment_id");

                entity.Property(e => e.Main).HasColumnName("main");

                entity.Property(e => e.Number)
                    .HasMaxLength(20)
                    .HasColumnName("number");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.DialInCode)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.DialInCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_phones__dial_in_code_id");

                entity.HasOne(d => d.Establishment)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.EstablishmentId)
                    .HasConstraintName("fk_phones__establishment_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("fk_phones__person_id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.CategoryId, "products_category_id_idx");

                entity.HasIndex(e => e.Code, "products_code_key")
                    .IsUnique();

                entity.HasIndex(e => e.TypeId, "products_type_id_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .HasColumnName("code");

                entity.Property(e => e.Content)
                    .HasMaxLength(50)
                    .HasColumnName("content");

                entity.Property(e => e.Cost)
                    .HasPrecision(19, 5)
                    .HasColumnName("cost");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("expiry_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Presentation)
                    .HasMaxLength(150)
                    .HasColumnName("presentation");

                entity.Property(e => e.ProfitPercentage).HasColumnName("profit_percentage");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("purchase_date");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.StockReplace).HasColumnName("stock_replace");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.WarnExpiration).HasColumnName("warn_expiration");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_products__category_id");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_products__type_id");

                entity.HasMany(d => d.Suppliers)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductSupplier",
                        l => l.HasOne<Supplier>().WithMany().HasForeignKey("SupplierId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_product_suppliers__supplier_id"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_product_suppliers__product_id"),
                        j =>
                        {
                            j.HasKey("ProductId", "SupplierId").HasName("product_suppliers_pkey");

                            j.ToTable("product_suppliers");

                            j.IndexerProperty<int>("ProductId").HasColumnName("product_id");

                            j.IndexerProperty<long>("SupplierId").HasColumnName("supplier_id");
                        });

                entity.HasMany(d => d.Taxes)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductTaxes",
                        l => l.HasOne<Tax>().WithMany().HasForeignKey("TaxId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_product_taxes__tax_id"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_product_taxes__product_id"),
                        j =>
                        {
                            j.HasKey("ProductId", "TaxId").HasName("product_taxes_pkey");

                            j.ToTable("product_taxes");

                            j.IndexerProperty<int>("ProductId").HasColumnName("product_id");

                            j.IndexerProperty<short>("TaxId").HasColumnName("tax_id");
                        });
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_categories");

                entity.HasIndex(e => e.Name, "product_categories_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("product_type");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Name, "roles_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Name)
                    .HasMaxLength(15)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("suppliers_pkey");

                entity.ToTable("suppliers");

                entity.Property(e => e.PersonId)
                    .ValueGeneratedNever()
                    .HasColumnName("person_id");

                entity.HasOne(d => d.Person)
                    .WithOne(p => p.Supplier)
                    .HasForeignKey<Supplier>(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_suppliers__person_id");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.ToTable("taxes");

                entity.HasIndex(e => e.Code, "taxes_code_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Percentage).HasColumnName("percentage");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => new { e.PersonId, e.Username }, "users_person_id_username_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AccountNonExpired).HasColumnName("account_non_expired");

                entity.Property(e => e.AccountNonLocked).HasColumnName("account_non_locked");

                entity.Property(e => e.CredentialsNonExpired).HasColumnName("credentials_non_expired");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .HasColumnName("username");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users__person_id");

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_user_roles__role_id"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_user_roles__user_id"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("user_roles_pkey");

                            j.ToTable("user_roles");

                            j.IndexerProperty<long>("UserId").HasColumnName("user_id");

                            j.IndexerProperty<short>("RoleId").HasColumnName("role_id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
