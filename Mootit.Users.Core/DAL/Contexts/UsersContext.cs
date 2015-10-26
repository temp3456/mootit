using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Mootit.Users.Core.DAL.Entities;
using Mootit.Users.Core.DAL.Mapping;

namespace Mootit.Users.Core.DAL.Contexts
{
    public partial class UsersContext : DbContext
    {
        static UsersContext()
        {
            Database.SetInitializer<UsersContext>(null);
        }

        public UsersContext()
            : base("Name=UsersContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TB_CustomersMap());
            modelBuilder.Configurations.Add(new TB_UsersMap());
        }
    }
}
