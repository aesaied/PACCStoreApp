using Microsoft.EntityFrameworkCore;

namespace StoreApp.Entities.Extensions
{
    public static class CountryExtension
    {

        public static ModelBuilder ConfigureCountry(this ModelBuilder modelBuilder)
        {


            var pal = new Country() { Id = 1, Name = "Palestine" };
            var jordan = new Country() { Id = 2, Name = "Jordan" };


            modelBuilder.Entity<Country>().HasData(pal, jordan);

            return modelBuilder;
        }


        public static ModelBuilder ConfigureCity(this ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<City>().Property(s => s.AlterName).HasDefaultValueSql("N'Name'");

            var defaulValue = new List<City>() { new City { Id = 1, Name = "Jerusalem", CountryId = 1 }, new City { Id = 2, Name = "Amman", CountryId = 2 } };

            modelBuilder.Entity<City>().HasData(defaulValue);

            return modelBuilder;
        }

    }
}
