using HospitalService.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalService.Data.EFContext
{
    public class SeedDb
    {
        public static void SeedUsers(UserManager<DbUser> userManager,
             EFContext _context)
        {
            var count = userManager.Users.Count();
            if (count <= 0)
            {
                string email = "telesuk@gmail.com";
                var roleName = "Admin";
                var user = new DbUser
                {
                    Email = email,
                    UserName = email,
                    PhoneNumber = "+38(067)855-22-65"
                };



                var result = userManager.CreateAsync(user, "Qwerty1-").Result;



                var userprofile = new PatientProfile
                {

                    Id = user.Id,
                    FirstName = "Максим",
                    LastName = "Максим",
                    Login = "Максим",
                    Image = @"~/images/1.jpg",
                    DateOfBirth = DateTime.Now
                };



                _context.PatientProfiles.Add(userprofile);
                _context.SaveChanges();
                result = userManager.AddToRoleAsync(user, roleName).Result;




            }
        }



        public static void SeedRoles(RoleManager<DbRole> roleManager)
        {
            var count = roleManager.Roles.Count();
            if (count <= 0)
            {
                var roleName = "Patient";
                var result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;



                roleName = "Admin";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;

                roleName = "Doctor";
                result = roleManager.CreateAsync(new DbRole
                {
                    Name = roleName
                }).Result;
            }
        }

        public static void SeedData(IServiceProvider services, IHostingEnvironment env, IConfiguration config)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<DbUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<DbRole>>();
                var context = scope.ServiceProvider.GetRequiredService<EFContext>();
                //var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();



                //SeederDB.SeedRegions(context);
                SeedDb.SeedRoles(managerRole);
            }
        }
    }
}
