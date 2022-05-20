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

        public Task CreateVoyagePrice(Voyage voyage)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetAverage(string voyageCode, Currency currency)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Voyage>> GetVoyages()
        {
            return await _context.Voyages.ToListAsync();
        }      

        public Task<bool> UpdateVoyagePrice(string voyageCode, decimal price, Currency currency, DateTimeOffset timestamp)
        {
            throw new NotImplementedException();
        }
    }
}
