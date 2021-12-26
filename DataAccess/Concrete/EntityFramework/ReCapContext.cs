using Core.Entities.Concrete;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlamak
    public class ReCapContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database=RentCarProjectDb;Trusted_Connection=true");

        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Rental> Rentals { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }    
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Card> Card{ get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Car>().HasOne(brand => brand.brand_id 


        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
