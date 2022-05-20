using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using PriceCalculator.API.Entities;

namespace PriceCalculator.API.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VoyageDbContext(serviceProvider.GetRequiredService<DbContextOptions<VoyageDbContext>>()))
            {
                // Look for any data exist or not.
                if (context.Voyages.Any())
                {
                    return;   // Data was already seeded
                }
                context.Voyages.AddRange(
                    new Voyage
                    {
                        VoyageCode = "451S",
                        
                        Container = "container1",
                        Currency = Currency.DKK,
                        Price = 109.90M,
                        TimeStamp = DateTime.Now
                    },
                    new Voyage
                    {
                        VoyageCode = "451S",
                        Container = "container2",
                        Currency = Currency.Euro,
                        Price = 200.90M,
                        TimeStamp = DateTime.Now
                    },
                   new Voyage
                   {
                       VoyageCode = "451S",
                       Container = "container3",
                       Currency = Currency.DKK,
                       Price = 300.90M,
                       TimeStamp = DateTime.Now
                   },
                     new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container3",
                         Currency = Currency.US,
                         Price = 144.90M,
                         TimeStamp = DateTime.Now
                     },
                     new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container4",
                         Currency = Currency.DKK,
                         Price = 188.90M,
                         TimeStamp = DateTime.Now
                     },
                     new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container5",
                         Currency = Currency.Euro,
                         Price = 122.90M,
                         TimeStamp = DateTime.Now
                     }, new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container6",
                         Currency = Currency.Euro,
                         Price = 132.90M,
                         TimeStamp = DateTime.Now
                     }, new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container7",
                         Currency = Currency.US,
                         Price = 152.90M,
                         TimeStamp = DateTime.Now
                     }
                     , new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container7",
                         Currency = Currency.Euro,
                         Price = 152.90M,
                         TimeStamp = DateTime.Now
                     },
                     new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container8",
                         Currency = Currency.US,
                         Price = 171.90M,
                         TimeStamp = DateTime.Now
                     });

                context.SaveChanges();
            }
        }
    }
}
