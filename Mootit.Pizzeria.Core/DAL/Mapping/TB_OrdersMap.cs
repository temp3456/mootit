using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Mootit.Pizzeria.Core.DAL.Entities;

namespace Mootit.Pizzeria.Core.DAL.Mapping
{
    public class TB_OrdersMap : EntityTypeConfiguration<Order>
    {
        public TB_OrdersMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TB_Orders");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Customer).HasColumnName("Customer");
            this.Property(t => t.Created).HasColumnName("Created").HasColumnType("datetime2");
            this.Property(t => t.Delivered).HasColumnName("Delivered").HasColumnType("datetime2");
        }
    }
}
