using Microsoft.EntityFrameworkCore;
using PriceCalculator.API.Data;
using PriceCalculator.API.Entities;
using PriceCalculator.API.External_Supported_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCalculator.API.Repositories
{
    public class VoyageRepository : IVoyageRepository
    {
        private readonly VoyageDbContext _context;
        public VoyageRepository(VoyageDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task UpdatePrice(Voyage voyage)
        {
            await _context.Voyages.AddAsync(voyage);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetAveragePrice(string voyageCode, Currency currency)
        {
            //Using Method Syntax
            var getAveragePrice = _context.Voyages.ToList()
                                 .Where(voy => voy.VoyageCode == voyageCode && voy.Currency == currency)
                                 .Average(voy => Convert.ToDecimal(voy.Price));

            return getAveragePrice;
        }

        public async Task<IEnumerable<Voyage>> GetVoyages()
        {
            return await _context.Voyages.ToListAsync();           
        }      

       
    }
}
