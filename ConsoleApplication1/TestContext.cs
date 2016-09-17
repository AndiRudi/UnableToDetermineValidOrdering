using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConsoleApplication1
{
    public class TestContext : DbContext
    {

        public TestContext() : base("TestContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}