using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Mootit.Users.Core.DAL.Entities;

namespace Mootit.Users.Core.DAL.Mapping
{
    public class TB_CustomersMap : EntityTypeConfiguration<Customer>
    {
        public TB_CustomersMap()
        {
            // Primary Key
            this.HasKey(t => t.Id_User);

            // Properties
            this.Property(t => t.Id_User)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Address)
                .HasMaxLength(255);

            this.Property(t => t.Fullname)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("TB_Customers");
            this.Property(t => t.Id_User).HasColumnName("Id_User");
            this.Property(t => t.PhoneNumer).HasColumnName("PhoneNumer");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Fullname).HasColumnName("Fullname");

            // Relationships
            this.HasRequired(t => t.Users)
                .WithOptional(t => t.Customers);

        }
    }
}
