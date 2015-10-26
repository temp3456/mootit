using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Mootit.Pizzeria.Core.DAL.Entities;

namespace Mootit.Pizzeria.Core.DAL.Mapping
{
    public class TB_BeveragesMap : EntityTypeConfiguration<Beverage>
    {
        public TB_BeveragesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TB_Beverages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
