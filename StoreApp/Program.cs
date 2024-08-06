using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using StoreApp.AppServices.City;
using StoreApp.AppServices.Country;
using StoreApp.AppServices.Country.Dtos;
using StoreApp.Entities;

namespace StoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // register Db Context as a Service
            builder.Services.AddDbContext<StoreAppContext>(
             options => options.UseSqlServer(builder.Configuration.GetConnectionString("StoreAppConnStr"))
             );



            builder.Services.AddApplicationServices();


            builder.Services.AddControllersWithViews();


            builder.Services.RegisterFluentValidators();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            // builder.Services.AddTransient<IValidator<CreateCountryDto>, CountryCreateValidator>();

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
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
