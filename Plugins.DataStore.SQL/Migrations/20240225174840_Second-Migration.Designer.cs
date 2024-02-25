﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plugins.DataStore.SQL;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    [DbContext(typeof(MarketContext))]
    [Migration("20240225174840_Second-Migration")]
    partial class SecondMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoreBusiness.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Healthy and juicy fruits",
                            Name = "Fruits"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Fresh and rich for vitamins",
                            Name = "Vegetables"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Halal and fatty meet",
                            Name = "Meet"
                        });
                });

            modelBuilder.Entity("CoreBusiness.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Name = "Banana",
                            Price = 2.5899999999999999,
                            Quantity = 52
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Name = "Apple",
                            Price = 3.25,
                            Quantity = 23
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Name = "Orange",
                            Price = 7.9900000000000002,
                            Quantity = 31
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            Name = "Tomato",
                            Price = 1.5900000000000001,
                            Quantity = 12
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            Name = "Cucumber",
                            Price = 2.25,
                            Quantity = 32
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 2,
                            Name = "Garlic",
                            Price = 4.3899999999999997,
                            Quantity = 45
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 3,
                            Name = "Stake",
                            Price = 52.990000000000002,
                            Quantity = 35
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 3,
                            Name = "Lamb",
                            Price = 43.25,
                            Quantity = 65
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 3,
                            Name = "Chicken",
                            Price = 37.990000000000002,
                            Quantity = 75
                        });
                });

            modelBuilder.Entity("CoreBusiness.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<int>("BeforeQuantity")
                        .HasColumnType("int");

                    b.Property<string>("CashierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoldQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeShtamp")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CoreBusiness.Product", b =>
                {
                    b.HasOne("CoreBusiness.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CoreBusiness.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
