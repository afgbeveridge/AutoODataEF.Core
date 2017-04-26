using Microsoft.EntityFrameworkCore;
using API.Generation.Support.Repository;

namespace EF.Example {

    public interface ICompanyContext : IDbContextDuckType {
        DbSet<Campaign> Campaigns { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<OrderLine> OrderLines { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
    }
}