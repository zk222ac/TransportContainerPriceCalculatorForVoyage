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

            var getall = await _context.Voyages.ToListAsync();

            var code = getall
                .Where(voy => voy.VoyageCode == voyageCode && voy.Currency == currency)
                .TakeLast(10).Average(voy => voy.Price);
            //Using Method Syntax           
            var getAveragePrice =(await _context.Voyages.ToListAsync())
                                  .Where(voy => voy.VoyageCode == voyageCode && voy.Currency == currency)
                                  .Average(voy => voy.Price);
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
