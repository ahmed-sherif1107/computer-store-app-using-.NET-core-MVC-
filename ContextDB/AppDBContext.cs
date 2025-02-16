using lab01ASPWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace lab01ASPWebApp.ContextDB
{
    public class AppDBContext : IdentityDbContext<IdentityUser>// write this to be able to use identities 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options) 
        { 
        }

        public DbSet<Items>items { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Employee> employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)////////////////////////////////////////////
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "select" }
             , new Category { Id = 2, Name = "mobile" }                    // to create a table category with its data set to the items here 
             , new Category { Id = 3, Name = "computer" }                  // this is called seeding and this data is called seed data
             , new Category { Id = 4, Name = "tablet" }
             );
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() 
                {
                Id = Guid.NewGuid().ToString(),// to greate a unigue id
                Name= "Admin",
                NormalizedName = "admin",
                ConcurrencyStamp = Guid.NewGuid().ToString()// to greate a unigue Concurrency Stamp
				},
			   new IdentityRole()
			   {
				   Id = Guid.NewGuid().ToString(),// to greate a unigue id
				   Name = "User",
				   NormalizedName = "user",
				   ConcurrencyStamp = Guid.NewGuid().ToString() // to greate a unigue Concurrency Stamp
			   }



				);
            base.OnModelCreating(modelBuilder); 
        }                                                                /////////////////////////////////////////////
    }
}
