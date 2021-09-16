using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldNet21
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HelloDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<HelloDBContext>>()))
            {
                // Look for any board games.
                if (context.Customers.Any())
                {
                    return;   // Data was already seeded
                }

                context.Customers.AddRange(
                    new Models.Customer
                    {
                        Id = 1,
                        Name = "Candy Land",
                        Address = "Hasbro",
                        City = "Istanbul",
                        Country = "Turkey"
                    },
                    new Models.Customer
                    {
                        Id = 2,
                        Name = "Candy Land",
                        Address = "Hasbro",
                        City = "Istanbul",
                        Country = "Turkey"
                    });

                context.SaveChanges();
            }
        }
    }
}
