using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using FizzWare.NBuilder;
using System.Linq;

namespace EF.Example.Migrations
{
    public partial class seeding : Migration {

        protected override void Up(MigrationBuilder migrationBuilder) {
            using (var ctx = new EFShim().Create(null)) {
                var custs = AddCustomers(ctx);
                var supps = AddSuppliers(ctx);
                var prods = AddProducts(ctx, supps);
                AddOrders(ctx, custs, supps, prods);
                ctx.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder) {

        }

        private IEnumerable<Customer> AddCustomers(CompanyContext ctx) {
            var customers = Builder<Customer>.CreateListOfSize(20).All().With(c => c.CustomerId = 0).Build();
            ctx.Customers.AddRange(customers.ToArray());
            return customers;
        }

        private IEnumerable<Product> AddProducts(CompanyContext ctx, IEnumerable<Supplier> supps) {
            var products = Builder<Product>.CreateListOfSize(32)
                .All()
                .With(p => p.OurProductId = Guid.NewGuid())
                .With(p => p.Supplier = Pick<Supplier>.RandomItemFrom(supps.ToList()))
                .Build();
            ctx.Products.AddRange(products.ToArray());
            return products;
        }

        private IEnumerable<Supplier> AddSuppliers(CompanyContext ctx) {
            var suppliers = Builder<Supplier>.CreateListOfSize(5).All().With(s => s.SupplierId = 0).Build();
            ctx.Suppliers.AddRange(suppliers.ToArray());
            return suppliers;
        }

        private void AddOrders(CompanyContext ctx, IEnumerable<Customer> customers, IEnumerable<Supplier> suppliers, IEnumerable<Product> products) {
            var orders = Builder<Order>.CreateListOfSize(25).All()
                            .With(o => o.OrderId = 0)
                            .With(o => o.Customer = Pick<Customer>.RandomItemFrom(customers.ToList()))
                            .Build();

            var itemCountGenerator = new RandomGenerator();

            orders.ToList().ForEach(o => {
                Builder<OrderLine>.CreateListOfSize(itemCountGenerator.Next(1, 10))
                    .All()
                        .With(line => line.OrderLineId = 0)
                        .With(line => line.Product = Pick<Product>.RandomItemFrom(products.ToList()))
                    .Build()
                    .ToList()
                    .ForEach(line => o.OrderLines.Add(line));
            });
            ctx.Orders.AddRange(orders.ToArray());
        }

    }
}
