using PriceCalculator.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceCalculator.API.Repositories
{
    public interface IVoyageRepository
    {
        Task<IEnumerable<Voyage>> GetVoyages();
        Task CreateVoyagePrice(Voyage voyage);
        Task<bool> UpdateVoyagePrice(string voyageCode, decimal price, Currency currency, DateTimeOffset timestamp);
        Task<decimal> GetAverage(string voyageCode, Currency currency);
    }
}
