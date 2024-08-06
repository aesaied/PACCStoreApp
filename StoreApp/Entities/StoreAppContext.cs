using Microsoft.EntityFrameworkCore;
using StoreApp.Entities.Extensions;

namespace StoreApp.Entities
{
    public class StoreAppContext : DbContext
    {


        // Add Constructor accept option  to  enable register Context as a Serevice
        public StoreAppContext(DbContextOptions<StoreAppContext> options)
            :  base(options)
        {
            
        }
        // Register Entities
        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ConfigureCountry();
            modelBuilder.ConfigureCity();



        }

    }
}
