using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Mootit.Users.Core.DAL.Entities;

namespace Mootit.Users.Core.DAL.Mapping
{
    public class TB_UsersMap : EntityTypeConfiguration<Entities.User>
    {
        public TB_UsersMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TB_Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Username).HasColumnName("Username");
        }
    }
}
