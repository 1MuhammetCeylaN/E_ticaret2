﻿using E_ticaret2.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace E_ticaret2.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Localhost
            //optionsBuilder.UseSqlServer(@"Server=LAPTOP-EMJSQFU7\SQLEXPRESS;Database=Eticaret2Db;Trusted_Connection=true;TrustServerCertificate=True; ");
            // base.OnConfiguring(optionsBuilder);


            // Free Host
            // optionsBuilder.UseSqlServer(@"workstation id=Ceylangiyim.mssql.somee.com;packet size=4096;user id=mceylan_SQLLogin_1;pwd=amq19ql891;data source=Ceylangiyim.mssql.somee.com;persist security info=False;initial catalog=Ceylangiyim;TrustServerCertificate=True");
             // base.OnConfiguring(optionsBuilder);

            // optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            // modelBuilder.ApplyConfiguration(new BrandConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // ÇALIŞAN DLL'iN İÇİNDEN BUL OTOMATİK OLARAK YAPAR

            base.OnModelCreating(modelBuilder);
        }
    }
}
