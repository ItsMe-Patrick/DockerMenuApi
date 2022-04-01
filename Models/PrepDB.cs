using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace DockerMenuApi.Models
{
    public class PrepDB
    {
        public static void PrePop(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                seedData(serviceScope.ServiceProvider.GetService<MenuContext>());
            }

        }

        public static void seedData(MenuContext context)
        {
            System.Console.WriteLine("Applying Migration ....");
            context.Database.Migrate();

            if (!context.MenusItem.Any())
            {
                System.Console.WriteLine("Adding Data - seeding.....");

                context.MenusItem.AddRange(
                    new Menu() {Name="Cofee",Price=10000},
                    new Menu() { Name = "Cofee", Price = 10000 },
                    new Menu() { Name = "Tea", Price = 10000 },
                    new Menu() { Name = "Premium Cofee", Price = 20000 },
                    new Menu() { Name = "Green Cofee", Price = 20000 },
                    new Menu() { Name = "Cake", Price = 30000 },
                    new Menu() { Name = "luxury Cake", Price = 45000 }
                    );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }

        }

    }
}
