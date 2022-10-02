using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class AppDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-OF7ALK0; database=UniveraProject;integrated security=true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                Active = true,
                Address = "Buca",
                PhoneNumber = "5398523538",
                AccountId = 1,
                Name = "Şükrü Hasta",
            });

            modelBuilder.Entity<Account>().HasData(
            new Account()
            {
                Id = 1,
                TotalBalance = 500,
                UserId = 1,
                Name = "FinansBank",
                Active = true,

            },

            new Account()
            {
                Id = 2,
                TotalBalance = 1500,
                UserId = 1,
                Name = "Akbank",
                Active = false
            },

            new Account()
            {
                Id = 3,
                TotalBalance = 7250,
                UserId = 1,
                Name = "Yapı Kredi",
                Active = true,

            },
            new Account()
            {
                Id = 4,
                TotalBalance = 1500,
                UserId = 1,
                Name = "Garanti",
                Active = true,

            }, 
            new Account()
            {
                Id = 5,
                TotalBalance = 200,
                UserId = 1,
                Name = "Vakıfbank",
                Active = true,

            });
        }
    }
}
