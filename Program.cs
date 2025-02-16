using lab01ASPWebApp.ContextDB;
using lab01ASPWebApp.Repo;
using lab01ASPWebApp.Repo.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace lab01ASPWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // to create the db from the code here
            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("MyConnection")
                ));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // to remove the error which will pop up on the screen if i try to register without adding this line 
                .AddEntityFrameworkStores<AppDBContext>();


            builder.Services.AddTransient(typeof(IRepo<>), typeof(MainRepo<>));// to add the srevices as a traisient(means each service is created for each request)  
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();



            app.MapControllerRoute(
                name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"); // the default page which will be opened on opening the application is 
            app.UseEndpoints(endpoints => endpoints.MapRazorPages()); // to be able to access the pages in the identity area 

            app.Run();
        }
    }
}
