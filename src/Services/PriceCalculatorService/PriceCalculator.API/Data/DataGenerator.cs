﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using PriceCalculator.API.Entities;
using System.Globalization;

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
                        Currency = Currency.US,
                        Price = 100.34M,
                        //Price = string.Format(new CultureInfo("en-US"), "{0:C}", 100.34),
                        TimeStamp = DateTime.Now
                    },
                    new Voyage
                    {
                        VoyageCode = "451S",
                        Container = "container2",
                        Currency = Currency.DKK,
                        Price = 200.78M,
                        //Price = string.Format(new CultureInfo("da-DK"), "{0:C}", 2.000),
                        TimeStamp = DateTime.Now
                    },
                   new Voyage
                   {
                       VoyageCode = "451S",
                       Container = "container3",
                       Currency = Currency.GBP,
                       Price = 300.67M,
                       //Price = string.Format(new CultureInfo("en-GB"), "{0:C}", 300.67),
                       TimeStamp = DateTime.Now
                   },
                     new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container4",
                         Currency = Currency.US,
                         Price = 400.87M,
                         //Price = string.Format(new CultureInfo("en-US"), "{0:C}", 400.87),
                         TimeStamp = DateTime.Now
                     },
                     new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container5",
                         Currency = Currency.DKK,
                         Price = 500.89M,
                         //Price = string.Format(new CultureInfo("da-DK"), "{0:C}", 500.89),                         
                         TimeStamp = DateTime.Now
                     },
                     new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container6",
                         Currency = Currency.GBP,
                         Price = 600.12M,
                         //Price = string.Format(new CultureInfo("en-GB"), "{0:C}", 600.12155),
                         TimeStamp = DateTime.Now
                     }, new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container7",
                         Currency = Currency.GBP,
                         Price = 700.67M,
                         //Price = string.Format(new CultureInfo("en-GB"), "{0:C}", 700.00),
                         TimeStamp = DateTime.Now
                     }, new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container8",
                         Currency = Currency.GBP,
                         Price = 800.45M,
                         //Price = string.Format(new CultureInfo("en-GB"), "{0:C}", 800.1),
                         TimeStamp = DateTime.Now
                     }
                     , new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container9",
                         Currency = Currency.US,
                         Price = 134.86M,
                         //Price = string.Format(new CultureInfo("en-US"), "{0:C}", 1456.12155),
                         TimeStamp = DateTime.Now
                     },
                     new Voyage
                     {
                         VoyageCode = "451S",
                         Container = "container10",
                         Currency = Currency.US,
                         Price =  123.87M,
                         //Price = string.Format(new CultureInfo("en-US"), "{0:C}", 1456.12155),
                         TimeStamp = DateTime.Now
                     },
                     new Voyage
                     {
                         VoyageCode = "LS45",
                         Container = "container11",
                         Currency = Currency.US,
                         Price = 465.98M,
                         //Price = string.Format(new CultureInfo("en-US"), "{0:C}", 1456.12155),
                         TimeStamp = DateTime.Now
                     },
                      new Voyage
                      {
                          VoyageCode = "LS45",
                          Container = "container12",
                          Currency = Currency.GBP,
                          Price = 700.98M,
                          //Price = string.Format(new CultureInfo("en-US"), "{0:C}", 1456.12155),
                          TimeStamp = DateTime.Now
                      }
                     );

                context.SaveChanges();
            }
        }
    }
}
