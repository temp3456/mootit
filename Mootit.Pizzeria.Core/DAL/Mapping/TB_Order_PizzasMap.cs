using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Mootit.Pizzeria.Core.DAL.Entities;

namespace Mootit.Pizzeria.Core.DAL.Mapping
{
    public class TB_Order_PizzasMap : EntityTypeConfiguration<Order_Pizzas>
    {
        public TB_Order_PizzasMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TB_Order_Pizzas");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Id_Order).HasColumnName("Id_Order");
            this.Property(t => t.Id_Pizza).HasColumnName("Id_Pizza");
            this.Property(t => t.Slice).HasColumnName("Slice");

            // Relationships
            this.HasRequired(t => t.Order)
                .WithMany(t => t.Order_Pizzas)
                .HasForeignKey(d => d.Id_Order);
            this.HasRequired(t => t.Pizza)
                .WithMany(t => t.Order_Pizzas)
                .HasForeignKey(d => d.Id_Pizza);

        }
    }
}
