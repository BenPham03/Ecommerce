using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext: IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }
        public DbSet<Bill> Bill {get; set;}
        public DbSet<BillInfo> BillInfo {get; set;}
        public DbSet<Category> Category {get; set;}
        public DbSet<Customer> Customer {get; set;}
        public DbSet<ImportInvoice> ImportInvoice {get; set;}
        public DbSet<ImportInvoiceInfo> ImportInvoiceInfo {get; set;}
        public DbSet<Product> Product {get; set;}
        public DbSet<Staff> Staff {get; set;}
        public DbSet<Supplier> Supplier {get; set;}
        public DbSet<Users> Users {get; set;}
        public DbSet<Comment> Comment {get; set;}
        public DbSet<DetailProduct> DetailProduct {get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}