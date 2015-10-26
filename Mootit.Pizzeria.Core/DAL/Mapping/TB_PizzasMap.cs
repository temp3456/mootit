using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Mootit.Pizzeria.Core.DAL.Entities;

namespace Mootit.Pizzeria.Core.DAL.Mapping
{
    public class TB_PizzasMap : EntityTypeConfiguration<Pizza>
    {
        public TB_PizzasMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Flavor)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TB_Pizzas");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Flavor).HasColumnName("Flavor");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
