using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Mootit.Pizzeria.Core.DAL.Mapping;
using Mootit.Pizzeria.Core.DAL.Entities;

namespace Mootit.Pizzeria.Core.Contexts
{
    public partial class PizzeriaContext : DbContext
    {
        static PizzeriaContext()
        {
            Database.SetInitializer<PizzeriaContext>(null);
        }

        public PizzeriaContext()
            : base("Name=PizzeriaContext")
        {
        }

        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Order_Beverages> TB_Order_Beverages { get; set; }
        public DbSet<Order_Desserts> TB_Order_Desserts { get; set; }
        public DbSet<Order_Pizzas> TB_Order_Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TB_BeveragesMap());
            modelBuilder.Configurations.Add(new TB_DessertsMap());
            modelBuilder.Configurations.Add(new TB_Order_BeveragesMap());
            modelBuilder.Configurations.Add(new TB_Order_DessertsMap());
            modelBuilder.Configurations.Add(new TB_Order_PizzasMap());
            modelBuilder.Configurations.Add(new TB_OrdersMap());
            modelBuilder.Configurations.Add(new TB_PizzasMap());
        }
    }
}
