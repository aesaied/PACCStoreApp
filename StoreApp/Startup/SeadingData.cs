using Microsoft.AspNetCore.Identity;
using StoreApp.Entities;
using StoreApp.Settings;

namespace StoreApp.Startup
{
    public static class SeadingData
    {

        public static async Task SeadRoles(RoleManager<AppStoreRole> roleManager)
        {



           if(!await roleManager.RoleExistsAsync(StoreAppSettings.Roles.Admins))
            {
                await roleManager.CreateAsync(new AppStoreRole() { Name=StoreAppSettings.Roles.Admins });
            }

            if (!await roleManager.RoleExistsAsync(StoreAppSettings.Roles.Manager))
            {
                await roleManager.CreateAsync(new AppStoreRole() { Name = StoreAppSettings.Roles.Manager });
            }

            if (!await roleManager.RoleExistsAsync(StoreAppSettings.Roles.User))
            {
                await roleManager.CreateAsync(new AppStoreRole() { Name = StoreAppSettings.Roles.User });
            }

        }
        

    }
}
