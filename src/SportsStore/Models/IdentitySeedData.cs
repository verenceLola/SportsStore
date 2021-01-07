using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;

namespace SportsStore.Models {
    public static class IdentitySeedData {
        private const string adminUser = "verenceLola";
        private const string adminPassword = "Password123;";

        public static async void EnsurePopulated(IApplicationBuilder app){
            using (IServiceScope scope = app.ApplicationServices.CreateScope()){
                UserManager<IdentityUser> userManager = (UserManager<IdentityUser>)scope.ServiceProvider.GetService(typeof(UserManager<IdentityUser>));
                IdentityUser user = await userManager.FindByIdAsync(adminUser);

                if (user == null){
                    user = new IdentityUser(adminUser);
                    Task<IdentityResult> createdUser =  userManager.CreateAsync(user, adminPassword);

                    if (!createdUser.Result.Succeeded){
                        Console.WriteLine($"Failed to create user {adminUser} with password {adminPassword} due to the following errors");
                        foreach (IdentityError error in createdUser.Result.Errors){
                            Console.WriteLine(error.Description);
                        }
                    }
                }

                IdentityUser newUser = await userManager.FindByIdAsync(adminUser);
            };
        }
    }
}
