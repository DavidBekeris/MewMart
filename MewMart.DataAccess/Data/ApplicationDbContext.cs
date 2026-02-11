using MewMart.Models;
using Microsoft.EntityFrameworkCore;

namespace MewMart.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Kattbollar", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Kattskålar", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Tygleksaker", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Grön kattboll",
                    Description = "Grön kattboll",
                    Manufacturer = "Made in China",
                    ISBN = "AB212",
                    ListPrize = 25,
                    Prize = 23,
                    Prize2 = 21,
                    Prize5 = 18,
                    CategoryId = 1,
                    ImageUrl=""
                },
new Product
{
    Id = 2,
    Title = "Röd kattboll",
    Description = "Röd kattboll",
    Manufacturer = "Made in China",
    ISBN = "AB213",
    ListPrize = 25,
    Prize = 23,
    Prize2 = 21,
    Prize5 = 18,
    CategoryId = 1,
    ImageUrl = ""
},
 new Product
 {
     Id = 3,
     Title = "Grön kattskål",
     Description = "Grön kattskål",
     Manufacturer = "Made in China",
     ISBN = "AC212",
     ListPrize = 25,
     Prize = 23,
     Prize2 = 21,
     Prize5 = 18,
     CategoryId = 2,
     ImageUrl = ""
 },
    new Product
    {
        Id = 4,
        Title = "Röd kattskål",
        Description = "Röd kattskål",
        Manufacturer = "Made in China",
        ISBN = "AC213",
        ListPrize = 25,
        Prize = 23,
        Prize2 = 21,
        Prize5 = 18,
        CategoryId = 2,
        ImageUrl = ""
    },
new Product
{
    Id = 5,
    Title = "Röd Tygleksak",
    Description = "Röd Tygleksak",
    Manufacturer = "Made in China",
    ISBN = "AD215",
    ListPrize = 25,
    Prize = 23,
    Prize2 = 21,
    Prize5 = 18,
    CategoryId = 3,
    ImageUrl = ""
},
 new Product
 {
     Id = 6,
     Title = "Grön Tygleksak",
     Description = "Grön Tygleksakl",
     Manufacturer = "Made in China",
     ISBN = "AD218",
     ListPrize = 25,
     Prize = 23,

     Prize2 = 21,
     Prize5 = 18,
     CategoryId = 3,
     ImageUrl = ""
 }

                );
        }
    }
}
