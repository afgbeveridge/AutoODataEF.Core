using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EF.Example;

namespace EF.Example.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20170425202009_seeding")]
    partial class seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF.Example.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<Guid?>("ProductOurProductId");

                    b.Property<DateTime?>("RunDate");

                    b.HasKey("CampaignId");

                    b.HasIndex("ProductOurProductId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("EF.Example.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EF.Example.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("Placed");

                    b.Property<DateTime?>("Shipped");

                    b.Property<decimal>("Total");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EF.Example.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<decimal?>("Discount");

                    b.Property<int?>("OrderId");

                    b.Property<Guid?>("ProductOurProductId");

                    b.HasKey("OrderLineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductOurProductId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("EF.Example.Product", b =>
                {
                    b.Property<Guid>("OurProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(512);

                    b.Property<int>("SupplierId");

                    b.Property<string>("TheirProductId")
                        .HasMaxLength(128);

                    b.Property<decimal>("WholesalePrice");

                    b.HasKey("OurProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EF.Example.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<int>("Rating");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("EF.Example.Campaign", b =>
                {
                    b.HasOne("EF.Example.Product")
                        .WithMany("Campaigns")
                        .HasForeignKey("ProductOurProductId");
                });

            modelBuilder.Entity("EF.Example.Order", b =>
                {
                    b.HasOne("EF.Example.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("EF.Example.OrderLine", b =>
                {
                    b.HasOne("EF.Example.Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId");

                    b.HasOne("EF.Example.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductOurProductId");
                });

            modelBuilder.Entity("EF.Example.Product", b =>
                {
                    b.HasOne("EF.Example.Supplier", "Supplier")
                        .WithMany("ProductsSupplied")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
