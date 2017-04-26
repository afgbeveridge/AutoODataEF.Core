using API.Generation.Support;
using Microsoft.EntityFrameworkCore;

namespace EF.Example {

    public class CompanyContext : DbContext, ICompanyContext {

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) {
        }

        public DbSet<Product> Products { get; set; }

        [ApiExclusion]
        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        [ApiResourceCollection(Name = "Clients")]
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        [ApiExclusion]
        public DbSet<OrderLine> OrderLines { get; set; }

    }

}
