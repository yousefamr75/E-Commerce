using E_Commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;

namespace E_Commerce.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        { 
        
        
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<products> products { get; set; }
        public DbSet<Company> companies { get; set; }
      

        public DbSet<ApplicationUser> applicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scief", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }



                );
            modelBuilder.Entity<products>().HasData(
                new products
                {
                    Id = 1,
                    title = "speak of time",
                    Author = "Balkey",
                    description = "time of time ",
                    ISBN = "55yy",
                    ListPrise = 99,
                    Prise = 90,
                    Prise50 = 85,
                    Prise100 = 80,
                    CategoryId = 1,
                    ImageUrl = "YY"

                });
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                   Name  = "speak of time",
                    StreetAddress= "Balkey",
                    City = "time of time ",
                    PostalCode = "55yy",
                    State = "LI",
                    phoneNumber = "01110873153",
                   

                });
           





        }

    }


    }

