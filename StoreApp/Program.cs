using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoreApp.AppServices.City;
using StoreApp.AppServices.Country;
using StoreApp.AppServices.Country.Dtos;
using StoreApp.Entities;
using StoreApp.Startup;

namespace StoreApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // register Db Context as a Service

            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilder.Authentication.
            builder.Services.AddDbContext<StoreAppContext>(
             options => options.UseSqlServer(builder.Configuration.GetConnectionString("StoreAppConnStr"))
             );

            //builder.Services.AddDefaultIdentity<AppStoreUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<StoreAppContext>();


            builder.Services.AddIdentity<AppStoreUser,AppStoreRole>(
                options => { 
                
                  
                }
                ).AddEntityFrameworkStores<StoreAppContext>().AddDefaultTokenProviders().AddDefaultUI();



            builder.Services.AddApplicationServices();


            builder.Services.AddControllersWithViews();


            builder.Services.RegisterFluentValidators();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            // builder.Services.AddTransient<IValidator<CreateCountryDto>, CountryCreateValidator>();

            var app = builder.Build();


            using (var  scope = app.Services.CreateScope())
            {
            
                var  roleManager=   scope.ServiceProvider.GetService<RoleManager<AppStoreRole>>();

                await SeadingData.SeadRoles(roleManager);   
            }

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


            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
