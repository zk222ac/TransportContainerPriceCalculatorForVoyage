using Microsoft.EntityFrameworkCore;
using PriceCalculator.API.Data;
using PriceCalculator.API.Entities;
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
            var getAveragePrice = await Task.FromResult(_context.Voyages.ToList().TakeLast(10)
                                  .Where(voy => voy.VoyageCode == voyageCode && voy.Currency == currency)
                                  .Average(voy => voy.Price));
            return getAveragePrice;
        }

        public async Task<IEnumerable<Voyage>> GetVoyages()
        {
            return await _context.Voyages.ToListAsync();           
        }
        public async  Task<Voyage> GetVoyageCode(string voyageCode)
        {
            return await _context.Voyages.FirstOrDefaultAsync(v => v.VoyageCode == voyageCode);           
        }       
    }
}
