﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240503200715_UpdateDatabaseSchema")]
    partial class UpdateDatabaseSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Bill", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<int?>("customerId")
                        .HasColumnType("int");

                    b.Property<int?>("staffid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("customerId");

                    b.HasIndex("staffid");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("api.Models.BillInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Billid")
                        .HasColumnType("int");

                    b.Property<int?>("Productid")
                        .HasColumnType("int");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Billid");

                    b.HasIndex("Productid");

                    b.ToTable("BillInfo");
                });

            modelBuilder.Entity("api.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("api.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("api.Models.ImportInvoice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Staffid")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Staffid");

                    b.ToTable("ImportInvoice");
                });

            modelBuilder.Entity("api.Models.ImportInvoiceInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("ImportInvoiceid")
                        .HasColumnType("int");

                    b.Property<int?>("Productid")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierID")
                        .HasColumnType("int");

                    b.Property<int>("count")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ImportInvoiceid");

                    b.HasIndex("Productid");

                    b.HasIndex("SupplierID");

                    b.ToTable("ImportInvoiceInfo");
                });

            modelBuilder.Entity("api.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("api.Models.Staff", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("INT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("api.Models.Supplier", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("api.Models.Users", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("Customerid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fund")
                        .HasColumnType("Decimal(18,2)");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Customerid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api.Models.Bill", b =>
                {
                    b.HasOne("api.Models.Customer", "customer")
                        .WithMany("Bills")
                        .HasForeignKey("customerId");

                    b.HasOne("api.Models.Staff", "staff")
                        .WithMany("Bills")
                        .HasForeignKey("staffid");

                    b.Navigation("customer");

                    b.Navigation("staff");
                });

            modelBuilder.Entity("api.Models.BillInfo", b =>
                {
                    b.HasOne("api.Models.Bill", "Bill")
                        .WithMany("BillInfos")
                        .HasForeignKey("Billid");

                    b.HasOne("api.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid");

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("api.Models.ImportInvoice", b =>
                {
                    b.HasOne("api.Models.Staff", "Staff")
                        .WithMany("ImportInvoices")
                        .HasForeignKey("Staffid");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("api.Models.ImportInvoiceInfo", b =>
                {
                    b.HasOne("api.Models.ImportInvoice", "ImportInvoice")
                        .WithMany("ImportInvoiceInfos")
                        .HasForeignKey("ImportInvoiceid");

                    b.HasOne("api.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid");

                    b.HasOne("api.Models.Supplier", "Supplier")
                        .WithMany("ImportInvoiceInfos")
                        .HasForeignKey("SupplierID");

                    b.Navigation("ImportInvoice");

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("api.Models.Product", b =>
                {
                    b.HasOne("api.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("api.Models.Users", b =>
                {
                    b.HasOne("api.Models.Customer", null)
                        .WithMany("Users")
                        .HasForeignKey("Customerid");
                });

            modelBuilder.Entity("api.Models.Bill", b =>
                {
                    b.Navigation("BillInfos");
                });

            modelBuilder.Entity("api.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("api.Models.Customer", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("api.Models.ImportInvoice", b =>
                {
                    b.Navigation("ImportInvoiceInfos");
                });

            modelBuilder.Entity("api.Models.Staff", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("ImportInvoices");
                });

            modelBuilder.Entity("api.Models.Supplier", b =>
                {
                    b.Navigation("ImportInvoiceInfos");
                });
#pragma warning restore 612, 618
        }
    }
}
