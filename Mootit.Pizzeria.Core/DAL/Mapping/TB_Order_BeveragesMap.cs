using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Mootit.Pizzeria.Core.DAL.Entities;

namespace Mootit.Pizzeria.Core.DAL.Mapping
{
    public class TB_Order_BeveragesMap : EntityTypeConfiguration<Order_Beverages>
    {
        public TB_Order_BeveragesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TB_Order_Beverages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Id_Order).HasColumnName("Id_Order");
            this.Property(t => t.Id_Beverage).HasColumnName("Id_Beverage");

            // Relationships
            this.HasRequired(t => t.Beverage)
                .WithMany(t => t.Order_Beverages)
                .HasForeignKey(d => d.Id_Beverage);
            this.HasRequired(t => t.Order)
                .WithMany(t => t.Order_Beverages)
                .HasForeignKey(d => d.Id_Order);

        }
    }
}
