using DoctorHouse.Constants;
using DoctorHouse.DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DoctorHouse.Helper
{
    public class SeederDB
    {
        public static void SeedData(UserManager<DbUser> userManager,
                   RoleManager<DbRole> roleManager)
        {

         //   CreateUpdateRole(roleManager, Roles.Admin);
         //   CreateUpdateRole(roleManager, Roles.Doctor);
         //   CreateUpdateRole(roleManager, Roles.Client);

          //  CreateUpdateUser(userManager, "admin@ukr.net", "Qwerty1-", Roles.Admin);

            //
            //  var email = "admin@gmail.com";
            //
            //  var findUser = userManager.FindByEmailAsync(email).Result;
            //  if (findUser == null)
            //  {
            //      var user = new DbUser
            //      {
            //          Email = email,
            //          UserName = email,
            //          Image = "https://cdn.pixabay.com/photo/2017/07/28/23/34/fantasy-picture-2550222_960_720.jpg",
            //          Age = 30,
            //          Phone = "+380957476156",
            //          Description = "PHP programmer"
            //      };
            //      var result = userManager.CreateAsync(user, "Qwerty1-").Result;
            //
            //      result = userManager.AddToRoleAsync(user, adminRoleName).Result;
            //  }
            //
            //  email = "user@gmail.com";
            //  findUser = userManager.FindByEmailAsync(email).Result;
            //  if (findUser == null)
            //  {
            //      var user = new DbUser
            //      {
            //          Email = email,
            //          UserName = email,
            //          Image = "https://cdn.pixabay.com/photo/2017/07/28/23/34/fantasy-picture-2550222_960_720.jpg",
            //          Age = 30,
            //          Phone = "+380988005535",
            //          Description = "User"
            //      };
            //      var result = userManager.CreateAsync(user, "Qwerty1-").Result;
            //
            //      result = userManager.AddToRoleAsync(user, userRoleName).Result;
            //  }
        }

        private static void CreateUpdateRole(RoleManager<DbRole> roleManager, string role)
        {
            var roleResult = roleManager.FindByNameAsync(role).Result;
            // var roleResult = roleManager.FindByNameAsync(adminRoleName).Result;
            if (roleResult == null)
            {
                var roleresult = roleManager.CreateAsync(new DbRole
                {
                    Name = role

                }).Result;
            }
        }
        private static void CreateUpdateUser(UserManager<DbUser> userManager, string email, string password, string role)
        {
            var findUser = userManager.FindByNameAsync(email).Result;
            // var roleResult = roleManager.FindByNameAsync(adminRoleName).Result;
            if (findUser == null)
            {
                var user = new DbUser
                {
                    Email = email,
                    UserName = email
                };
                var result = userManager.CreateAsync(user, password).Result;
                result = userManager.AddToRoleAsync(user, password).Result;
            }
        }
        public static void SeedDataByAS(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                SeederDB.SeedData(manager, managerRole);
            }
        }
    }
}
