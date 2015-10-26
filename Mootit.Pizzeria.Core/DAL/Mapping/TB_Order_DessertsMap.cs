using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Mootit.Pizzeria.Core.DAL.Entities;

namespace Mootit.Pizzeria.Core.DAL.Mapping
{
    public class TB_Order_DessertsMap : EntityTypeConfiguration<Order_Desserts>
    {
        public TB_Order_DessertsMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TB_Order_Desserts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Id_Order).HasColumnName("Id_Order");
            this.Property(t => t.Id_Dessert).HasColumnName("Id_Dessert");

            // Relationships
            this.HasRequired(t => t.Desserts)
                .WithMany(t => t.Order_Desserts)
                .HasForeignKey(d => d.Id_Dessert);
            this.HasRequired(t => t.Orders)
                .WithMany(t => t.Order_Desserts)
                .HasForeignKey(d => d.Id_Order);

        }
    }
}
